using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.BLL.Contracts;
using App.DAL.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
using App.BLL.DTO;
using Asp.Versioning;
using Base.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.ApiControllers
{
    /// <summary>
    /// API Controller for managing Person entities.
    /// Provides endpoints to handle CRUD operations for Person resources.
    /// Requires user authentication via JWT Bearer authentication scheme.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IAppBLL _bll;
        
        private readonly App.DTO.v1.Mappers.PersonMapper _mapper =
            new App.DTO.v1.Mappers.PersonMapper();
        
        public PersonController(IAppBLL bll, ILogger<PersonController> logger)
        {
            _bll = bll;
            _logger = logger;
        }
        
        /// <summary>
        /// Get all persons for currently logged-in user
        /// </summary>
        /// <returns>List of persons</returns>
        [HttpGet]
        [Produces( "application/json" )]
        [ProducesResponseType( typeof( IEnumerable<App.DTO.v1.Person> ), 200 )]
        [ProducesResponseType( 404 )]
        public async Task<ActionResult<IEnumerable<App.DTO.v1.Person>>> GetPersons()
        {
            var data = await _bll.PersonService.AllAsync(User.GetUserId());
            var res = data.Select(x => _mapper.Map(x)!).ToList();

            return res;
        }

        /// <summary>
        /// Retrieves a specific person by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the person to retrieve.</param>
        /// <returns>The requested person if found, or a 404 Not Found response if the person does not exist.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<App.DTO.v1.Person>> GetPerson(Guid id)
        {
            var person = await _bll.PersonService.FindAsync(id, User.GetUserId());

            if (person == null)
            {
                return NotFound();
            }

            return _mapper.Map(person)!;
        }

        /// <summary>
        /// Updates an existing Person entity.
        /// </summary>
        /// <param name="id">The unique identifier of the Person to be updated.</param>
        /// <param name="person">The updated Person object containing the new data.</param>
        /// <returns>An IActionResult indicating the outcome of the operation.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(Guid id, App.DTO.v1.Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            await _bll.PersonService.UpdateAsync(_mapper.Map(person)!, User.GetUserId());
            await _bll.SaveChangesAsync();
                
            return NoContent();
        }

        /// <summary>
        /// Adds a new person entity to the system.
        /// </summary>
        /// <param name="person">The person data to be added.</param>
        /// <returns>The created person with assigned identifier and additional details.</returns>
        [HttpPost]
        public async Task<ActionResult<App.DTO.v1.Person>> PostPerson(App.DTO.v1.Person person)
        {
            var bllEntity = _mapper.Map(person);
            _bll.PersonService.Add(bllEntity, User.GetUserId());
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new
            {
                id = bllEntity.Id,
                version = HttpContext.GetRequestedApiVersion()!.ToString()
            }, person);
        }

        /// <summary>
        /// Deletes a person by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the person to be deleted.</param>
        /// <returns>A NoContent result if the deletion is successful.</returns>
        [Produces("application/json")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            await _bll.PersonService.RemoveAsync(id, User.GetUserId());
            await _bll.SaveChangesAsync();
            return NoContent();
        }
    }
}
