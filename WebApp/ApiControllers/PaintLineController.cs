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
    public class PaintLineController : ControllerBase
    {
        private readonly ILogger<PaintTypeController> _logger;
        private readonly IAppBLL _bll;
        
        private readonly App.DTO.v1.Mappers.PaintLineMapper _mapper =
            new App.DTO.v1.Mappers.PaintLineMapper();

        public PaintLineController(IAppBLL bll, ILogger<PaintTypeController> logger)
        {
            _bll = bll;
            _logger = logger;
        }

        /// <summary>
        ///  Get all PaintLines
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces( "application/json" )]
        [ProducesResponseType( typeof( IEnumerable<App.DTO.v1.PaintLine> ), 200 )]
        [ProducesResponseType( 404 )]
        public async Task<ActionResult<IEnumerable<App.DTO.v1.PaintLine>>> GetPaintLines()
        {
            var data = await _bll.PaintLineService.AllAsync();
            return data.Select(x => _mapper.Map(x)!).ToList();
        }

        // GET: api/PaintLine/5
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<ActionResult<App.DTO.v1.PaintLine>> GetPaintLine(Guid id)
        {
            var paintLine = await _bll.PaintLineService.FindAsync(id);

            if (paintLine == null)
            {
                return NotFound();
            }

            return _mapper.Map(paintLine)!;
        }

        // PUT: api/PaintLine/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaintLine(Guid id, App.DTO.v1.PaintLine paintLine)
        {
            if (id != paintLine.Id)
            {
                return BadRequest();
            }

            await _bll.PaintLineService.UpdateAsync(_mapper.Map(paintLine)!);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/PaintLine
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost]
        public async Task<ActionResult<App.DTO.v1.PaintLine>> PostPaintLine(App.DTO.v1.PaintLine paintLine)
        {
            var data = _mapper.Map(paintLine)!;
            _bll.PaintLineService.Add(data);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetPaintLine", new { id = data.Id }, paintLine);
        }

        // DELETE: api/PaintLine/5
        [Produces("application/json")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaintLine(Guid id)
        {
            await _bll.PaintLineService.RemoveAsync(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
