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
    public class PaintController : ControllerBase
    {
        private readonly ILogger<PaintTypeController> _logger;
        private readonly IAppBLL _bll;
        
        private readonly App.DTO.v1.Mappers.PaintMapper _mapper =
            new App.DTO.v1.Mappers.PaintMapper();

        public PaintController(IAppBLL bll, ILogger<PaintTypeController> logger)
        {
            _bll = bll;
            _logger = logger;
        }
        
        /// <summary>
        ///  Get all Paints
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces( "application/json" )]
        [ProducesResponseType( typeof( IEnumerable<App.DTO.v1.Paint> ), 200 )]
        [ProducesResponseType( 404 )]
        public async Task<ActionResult<IEnumerable<App.DTO.v1.Paint>>> GetPaints()
        {
            var data = await _bll.PaintService.AllAsync();
            return data.Select(x => _mapper.Map(x)!).ToList();
        }

        // GET: api/Paint/5
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<ActionResult<App.DTO.v1.Paint>> GetPaint(Guid id)
        {
            var paint = await _bll.PaintService.FindAsync(id);

            if (paint == null)
            {
                return NotFound();
            }

            return _mapper.Map(paint)!;
        }

        // PUT: api/Paint/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaint(Guid id, App.DTO.v1.Paint paint)
        {
            if (id != paint.Id)
            {
                return BadRequest();
            }

            await _bll.PaintService.UpdateAsync(_mapper.Map(paint)!);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Paint
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost]
        public async Task<ActionResult<App.DTO.v1.Paint>> PostPaint(App.DTO.v1.Paint paint)
        {
            var data = _mapper.Map(paint)!;
            _bll.PaintService.Add(data);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetPaint", new { id = data.Id }, paint);
        }

        // DELETE: api/Paint/5
        [Produces("application/json")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaint(Guid id)
        {
            await _bll.PaintService.RemoveAsync(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
        
    }
}
