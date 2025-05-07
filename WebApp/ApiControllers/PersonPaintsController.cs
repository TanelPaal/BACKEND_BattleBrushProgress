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
using Base.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.ApiControllers
{
    /// <summary>
    /// API Controller for managing PersonPaints resources.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for creating, retrieving, updating, and deleting PersonPaints entities.
    /// Only accessible to authenticated users.
    /// </remarks>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PersonPaintsController : ControllerBase
    {
        private readonly ILogger<PersonPaintsController> _logger;
        private readonly IAppBLL _bll;
        
        private readonly App.DTO.v1.Mappers.PersonPaintsMapper _mapper =
            new App.DTO.v1.Mappers.PersonPaintsMapper();

        public PersonPaintsController(IAppBLL bll, ILogger<PersonPaintsController> logger)
        {
            _bll = bll;
            _logger = logger;
        }
        
        /// <summary>
        /// Get all PersonPaints for current user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces( "application/json" )]
        [ProducesResponseType( typeof( IEnumerable<App.DTO.v1.PersonPaints> ), 200 )]
        [ProducesResponseType( 404 )]
        public async Task<ActionResult<IEnumerable<App.DTO.v1.PersonPaints>>> GetPersonPaints()
        {
            var data = await _bll.PersonPaintsService.AllAsync(User.GetUserId());
            var res = data.Select(x => _mapper.Map(x)!).ToList();
            return res;
        }
        
        /// <summary>
        /// Get PersonPaints by id - owned by current user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [ProducesResponseType(typeof(App.DTO.v1.PersonPaints), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<App.DTO.v1.PersonPaints>> GetPersonPaints(Guid id)
        {
            var personPaints = await _bll.PersonPaintsService.FindAsync(id, User.GetUserId());

            if (personPaints == null)
            {
                return NotFound();
            }

            return _mapper.Map(personPaints)!;
        }
        
        /// <summary>
        /// Update Person Paints by id - owned by current user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personPaints"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonPaints(Guid id, App.DTO.v1.PersonPaints personPaints)
        {
            if (id != personPaints.Id)
            {
                return BadRequest();
            }

            await _bll.PersonPaintsService.UpdateAsync(_mapper.Map(personPaints)!, User.GetUserId());
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        /// <summary>
        ///  Create new PersonPaints - owned by current user
        /// </summary>
        /// <param name="personPaints"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(App.DTO.v1.PersonPaints), StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<ActionResult<PersonPaints>> PostPersonPaints(App.DTO.v1.PersonPaints personPaints)
        {
            var bllPersonPaints = _mapper.Map(personPaints);
            _bll.PersonPaintsService.Add(bllPersonPaints, User.GetUserId());
            await _bll.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPersonPaints), new { id = bllPersonPaints.Id }, personPaints);
        }
        
        /// <summary>
        /// Delete PersonPaints by id - owned by current user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonPaints(Guid id)
        {
            await _bll.PersonPaintsService.RemoveAsync(id, User.GetUserId());
            await _bll.SaveChangesAsync();
            return NoContent();
        }
    }
}
