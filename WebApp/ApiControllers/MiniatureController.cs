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
    public class MiniatureController : ControllerBase
    {
        private readonly ILogger<MiniatureController> _logger;
        private readonly IAppBLL _bll;
        
        private readonly App.DTO.v1.Mappers.MiniatureMapper _mapper =
            new App.DTO.v1.Mappers.MiniatureMapper();

        public MiniatureController(IAppBLL bll, ILogger<MiniatureController> logger)
        {
            _bll = bll;
            _logger = logger;
        }

        /// <summary>
        ///  Get all Miniatures
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces( "application/json" )]
        [ProducesResponseType( typeof( IEnumerable<App.DTO.v1.PaintLine> ), 200 )]
        [ProducesResponseType( 404 )]
        public async Task<ActionResult<IEnumerable<App.DTO.v1.Miniature>>> GetMiniatures()
        {
            var data = await _bll.MiniatureService.AllAsync();
            return data.Select(x => _mapper.Map(x)!).ToList();
        }

        // GET: api/Miniature/5
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<ActionResult<App.DTO.v1.Miniature>> GetMiniature(Guid id)
        {
            var miniature = await _bll.MiniatureService.FindAsync(id);

            if (miniature == null)
            {
                return NotFound();
            }

            return _mapper.Map(miniature)!;
        }

        // PUT: api/Miniature/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiniature(Guid id, App.DTO.v1.Miniature miniature)
        {
            if (id != miniature.Id)
            {
                return BadRequest();
            }

            await _bll.MiniatureService.UpdateAsync(_mapper.Map(miniature)!);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Miniature
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost]
        public async Task<ActionResult<App.DTO.v1.Miniature>> PostMiniature(App.DTO.v1.Miniature miniature)
        {
            var data = _mapper.Map(miniature)!;
            _bll.MiniatureService.Add(data);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetMiniature", new { id = data.Id }, miniature);
        }

        // DELETE: api/Miniature/5
        [Produces("application/json")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMiniature(Guid id)
        {
            await _bll.MiniatureService.RemoveAsync(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
