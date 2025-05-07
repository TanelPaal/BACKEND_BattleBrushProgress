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
    public class MiniStateController : ControllerBase
    {
        private readonly ILogger<PaintTypeController> _logger;
        private readonly IAppBLL _bll;
        
        private readonly App.DTO.v1.Mappers.MiniStateMapper _mapper =
            new App.DTO.v1.Mappers.MiniStateMapper();

        public MiniStateController(IAppBLL bll, ILogger<PaintTypeController> logger)
        {
            _bll = bll;
            _logger = logger;
        }

        /// <summary>
        ///  Get all MiniStates
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces( "application/json" )]
        [ProducesResponseType( typeof( IEnumerable<App.DTO.v1.MiniState> ), 200 )]
        [ProducesResponseType( 404 )]
        public async Task<ActionResult<IEnumerable<App.DTO.v1.MiniState>>> GetMiniStates()
        {
            var data = await _bll.MiniStateService.AllAsync();
            return data.Select(x => _mapper.Map(x)!).ToList();
        }

        // GET: api/MiniState/5
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<ActionResult<App.DTO.v1.MiniState>> GetMiniState(Guid id)
        {
            var miniState = await _bll.MiniStateService.FindAsync(id);

            if (miniState == null)
            {
                return NotFound();
            }

            return _mapper.Map(miniState)!;
        }

        // PUT: api/MiniState/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiniState(Guid id, App.DTO.v1.MiniState miniState)
        {
            if (id != miniState.Id)
            {
                return BadRequest();
            }

            _bll.MiniStateService.UpdateAsync(_mapper.Map(miniState)!);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/MiniState
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost]
        public async Task<ActionResult<App.DTO.v1.MiniState>> PostMiniState(App.DTO.v1.MiniState miniState)
        {
            var data = _mapper.Map(miniState)!;
            _bll.MiniStateService.Add(data);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetMiniState", new { id = data.Id }, miniState);
        }

        // DELETE: api/MiniState/5
        [Produces("application/json")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMiniState(Guid id)
        {
            await _bll.PaintTypeService.RemoveAsync(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
