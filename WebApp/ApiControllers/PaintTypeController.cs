using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.BLL.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
using App.Domain;
using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.ApiControllers
{
    /// <summary>
    /// Controller for handling operations related to PaintType entities.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PaintTypeController : ControllerBase
    {
        private readonly ILogger<PaintTypeController> _logger;
        private readonly IAppBLL _bll;
        
        private readonly App.DTO.v1.Mappers.PaintTypeMapper _mapper =
            new App.DTO.v1.Mappers.PaintTypeMapper();

        public PaintTypeController(IAppBLL bll, ILogger<PaintTypeController> logger)
        {
            _bll = bll;
            _logger = logger;
        }
        
        /// <summary>
        ///  Get all PaintTypes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces( "application/json" )]
        [ProducesResponseType( typeof( IEnumerable<App.DTO.v1.PaintType> ), 200 )]
        [ProducesResponseType( 404 )]
        public async Task<ActionResult<IEnumerable<App.DTO.v1.PaintType>>> GetPaintTypes()
        {
            var data = await _bll.PaintTypeService.AllAsync();
            return data.Select(x => _mapper.Map(x)!).ToList();
        }

        /// <summary>
        /// Retrieves a specific PaintType by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the PaintType to retrieve.</param>
        /// <returns>Returns the PaintType object if found; otherwise, returns a NotFound result.</returns>
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<ActionResult<App.DTO.v1.PaintType>> GetPaintType(Guid id)
        {
            var paintType = await _bll.PaintTypeService.FindAsync(id);

            if (paintType == null)
            {
                return NotFound();
            }

            return _mapper.Map(paintType)!;
        }

        /// <summary>
        /// Updates the specified PaintType entity in the system.
        /// </summary>
        /// <param name="id">The identifier of the PaintType to update.</param>
        /// <param name="paintType">The PaintType object containing the updated information.</param>
        /// <returns>Returns an IActionResult indicating the outcome of the operation.</returns>
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaintType(Guid id, App.DTO.v1.PaintType paintType)
        {
            if (id != paintType.Id)
            {
                return BadRequest();
            }
            
            await _bll.PaintTypeService.UpdateAsync(_mapper.Map(paintType)!);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Creates a new PaintType entity.
        /// </summary>
        /// <param name="paintType">The PaintType entity to create.</param>
        /// <returns>
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost]
        public async Task<ActionResult<App.DTO.v1.PaintType>> PostPaintType(App.DTO.v1.PaintType paintType)
        {
            var data = _mapper.Map(paintType)!;
            _bll.PaintTypeService.Add(data);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetPaintType", new { id = data.Id }, paintType);
        }

        /// <summary>
        /// Deletes a PaintType entity by its identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the PaintType to delete.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [Produces("application/json")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaintType(Guid id)
        {
            await _bll.PaintTypeService.RemoveAsync(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
