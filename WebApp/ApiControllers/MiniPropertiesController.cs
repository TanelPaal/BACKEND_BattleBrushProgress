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
    /// Controller responsible for handling operations related to MiniProperties.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MiniPropertiesController : ControllerBase
    {
        private readonly ILogger<MiniPropertiesController> _logger;
        private readonly IAppBLL _bll;
        
        private readonly App.DTO.v1.Mappers.MiniPropertiesMapper _mapper =
            new App.DTO.v1.Mappers.MiniPropertiesMapper();

        public MiniPropertiesController(IAppBLL bll, ILogger<MiniPropertiesController> logger)
        {
            _bll = bll;
            _logger = logger;
        }

        /// <summary>
        ///  Get all MiniProperties
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces( "application/json" )]
        [ProducesResponseType( typeof( IEnumerable<App.DTO.v1.MiniProperties> ), 200 )]
        [ProducesResponseType( 404 )]
        public async Task<ActionResult<IEnumerable<App.DTO.v1.MiniProperties>>> GetMiniProperties()
        {
            var data = await _bll.MiniPropertiesService.AllAsync();
            return data.Select(x => _mapper.Map(x)!).ToList();
        }

        /// <summary>
        /// Retrieves all MiniProperties.
        /// </summary>
        /// <returns>A collection of MiniProperties.</returns>
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<ActionResult<App.DTO.v1.MiniProperties>> GetMiniProperties(Guid id)
        {
            var miniProperties = await _bll.MiniPropertiesService.FindAsync(id);

            if (miniProperties == null)
            {
                return NotFound();
            }

            return _mapper.Map(miniProperties)!;
        }

        /// <summary>
        /// Updates an existing MiniProperties entity.
        /// </summary>
        /// <param name="id">The unique identifier of the MiniProperties entity to update.</param>
        /// <param name="miniProperties">The updated MiniProperties entity.</param>
        /// <returns>An IActionResult representing the result of the update operation.</returns>
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiniProperties(Guid id, App.DTO.v1.MiniProperties miniProperties)
        {
            if (id != miniProperties.Id)
            {
                return BadRequest();
            }

            await _bll.MiniPropertiesService.UpdateAsync(_mapper.Map(miniProperties)!);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Adds a new MiniProperties entry to the database.
        /// </summary>
        /// <param name="miniProperties">The MiniProperties object to be added.</param>
        /// <returns>An ActionResult containing the created MiniProperties object.</returns>
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost]
        public async Task<ActionResult<App.DTO.v1.MiniProperties>> PostMiniProperties(App.DTO.v1.MiniProperties miniProperties)
        {
            var data = _mapper.Map(miniProperties)!;
            _bll.MiniPropertiesService.Add(data);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetMiniProperties", new { id = data.Id }, miniProperties);
        }

        /// <summary>
        /// Deletes a specific MiniProperty identified by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the MiniProperty to be deleted.</param>
        /// <returns>An IActionResult indicating the outcome of the deletion operation.</returns>
        [Produces("application/json")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMiniProperties(Guid id)
        {
            await _bll.MiniPropertiesService.RemoveAsync(id);
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }
    }
}
