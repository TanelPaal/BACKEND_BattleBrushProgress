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
    public class BrandController : ControllerBase
    {
        private readonly ILogger<BrandController> _logger;
        private readonly IAppBLL _bll;
        
        private readonly App.DTO.v1.Mappers.BrandMapper _mapper =
            new App.DTO.v1.Mappers.BrandMapper();

        public BrandController(IAppBLL bll, ILogger<BrandController> logger)
        {
            _bll = bll;
            _logger = logger;
        }

        /// <summary>
        ///  Get all Brands
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces( "application/json" )]
        [ProducesResponseType( typeof( IEnumerable<App.DTO.v1.Brand> ), 200 )]
        [ProducesResponseType( 404 )]
        public async Task<ActionResult<IEnumerable<App.DTO.v1.Brand>>> GetBrands()
        {
            var data = await _bll.BrandService.AllAsync();
            return data.Select(x => _mapper.Map(x)!).ToList();
        }

        // GET: api/Brand/5
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<ActionResult<App.DTO.v1.Brand>> GetBrand(Guid id)
        {
            var brand = await _bll.BrandService.FindAsync(id);

            if (brand == null)
            {
                return NotFound();
            }

            return _mapper.Map(brand)!;
        }

        // PUT: api/Brand/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrand(Guid id, App.DTO.v1.Brand brand)
        {
            if (id != brand.Id)
            {
                return BadRequest();
            }

            await _bll.BrandService.UpdateAsync(_mapper.Map(brand)!);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Brand
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost]
        public async Task<ActionResult<App.DTO.v1.Brand>> PostBrand(App.DTO.v1.Brand brand)
        {
            var data = _mapper.Map(brand)!;
            _bll.BrandService.Add(data);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetBrand", new { id = data.Id }, brand);
        }

        // DELETE: api/Brand/5
        [Produces("application/json")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(Guid id)
        {
            await _bll.BrandService.RemoveAsync(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
        
    }
}
