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
    public class MiniManufacturerController : ControllerBase
    {
        private readonly ILogger<MiniManufacturerController> _logger;
        private readonly IAppBLL _bll;
        
        private readonly App.DTO.v1.Mappers.MiniManufacturerMapper _mapper =
            new App.DTO.v1.Mappers.MiniManufacturerMapper();

        public MiniManufacturerController(IAppBLL bll, ILogger<MiniManufacturerController> logger)
        {
            _bll = bll;
            _logger = logger;
        }

        /// <summary>
        ///  Get all MiniManufacturers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces( "application/json" )]
        [ProducesResponseType( typeof( IEnumerable<App.DTO.v1.MiniManufacturer> ), 200 )]
        [ProducesResponseType( 404 )]
        public async Task<ActionResult<IEnumerable<App.DTO.v1.MiniManufacturer>>> GetMiniManufacturers()
        {
            var data = await _bll.MiniManufacturerService.AllAsync();
            return data.Select(x => _mapper.Map(x)!).ToList();
        }

        // GET: api/MiniManufacturer/5
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<ActionResult<App.DTO.v1.MiniManufacturer>> GetMiniManufacturer(Guid id)
        {
            var miniManufacturer = await _bll.MiniManufacturerService.FindAsync(id);

            if (miniManufacturer == null)
            {
                return NotFound();
            }

            return _mapper.Map(miniManufacturer)!;
        }

        // PUT: api/MiniManufacturer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiniManufacturer(Guid id, App.DTO.v1.MiniManufacturer miniManufacturer)
        {
            if (id != miniManufacturer.Id)
            {
                return BadRequest();
            }

            await _bll.MiniManufacturerService.UpdateAsync(_mapper.Map(miniManufacturer)!);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/MiniManufacturer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost]
        public async Task<ActionResult<App.DTO.v1.MiniManufacturer>> PostMiniManufacturer(App.DTO.v1.MiniManufacturer miniManufacturer)
        {
            var data = _mapper.Map(miniManufacturer)!;
            _bll.MiniManufacturerService.Add(data);
            await _bll.SaveChangesAsync();


            return CreatedAtAction("GetMiniManufacturer", new { id = data.Id }, miniManufacturer);
        }

        // DELETE: api/MiniManufacturer/5
        [Produces("application/json")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMiniManufacturer(Guid id)
        {
            await _bll.MiniManufacturerService.RemoveAsync(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
