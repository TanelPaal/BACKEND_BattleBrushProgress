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

        // GET: api/MiniProperties/5
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

        // PUT: api/MiniProperties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // POST: api/MiniProperties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // DELETE: api/MiniProperties/5
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
