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
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MiniFactionController : ControllerBase
    {
        private readonly ILogger<MiniFactionController> _logger;
        private readonly IAppBLL _bll;
        
        private readonly App.DTO.v1.Mappers.MiniFactionMapper _mapper =
            new App.DTO.v1.Mappers.MiniFactionMapper();

        public MiniFactionController(IAppBLL bll, ILogger<MiniFactionController> logger)
        {
            _bll = bll;
            _logger = logger;
        }

        /// <summary>
        ///  Get all MiniFactions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces( "application/json" )]
        [ProducesResponseType( typeof( IEnumerable<App.DTO.v1.MiniFaction> ), 200 )]
        [ProducesResponseType( 404 )]
        public async Task<ActionResult<IEnumerable<App.DTO.v1.MiniFaction>>> GetMiniFactions()
        {
            var data = await _bll.MiniFactionService.AllAsync();
            return data.Select(x => _mapper.Map(x)!).ToList();
        }

        // GET: api/MiniFaction/5
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<ActionResult<App.DTO.v1.MiniFaction>> GetMiniFaction(Guid id)
        {
            var miniFaction = await _bll.MiniFactionService.FindAsync(id);

            if (miniFaction == null)
            {
                return NotFound();
            }

            return _mapper.Map(miniFaction)!;
        }

        // PUT: api/MiniFaction/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiniFaction(Guid id, App.DTO.v1.MiniFaction miniFaction)
        {
            if (id != miniFaction.Id)
            {
                return BadRequest();
            }
            
            await _bll.MiniFactionService.UpdateAsync(_mapper.Map(miniFaction)!);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/MiniFaction
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost]
        public async Task<ActionResult<App.DTO.v1.MiniFaction>> PostMiniFaction(App.DTO.v1.MiniFaction miniFaction)
        {
            var data = _mapper.Map(miniFaction)!;
            _bll.MiniFactionService.Add(data);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetMiniFaction", new { id = data.Id }, miniFaction);
        }

        // DELETE: api/MiniFaction/5
        [Produces("application/json")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMiniFaction(Guid id)
        {
            await _bll.MiniFactionService.RemoveAsync(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
