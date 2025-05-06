using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
using App.Domain;
using Asp.Versioning;

namespace WebApp.ApiControllers
{
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class MiniManufacturerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MiniManufacturerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MiniManufacturer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MiniManufacturer>>> GetMiniManufacturers()
        {
            return await _context.MiniManufacturers.ToListAsync();
        }

        // GET: api/MiniManufacturer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MiniManufacturer>> GetMiniManufacturer(Guid id)
        {
            var miniManufacturer = await _context.MiniManufacturers.FindAsync(id);

            if (miniManufacturer == null)
            {
                return NotFound();
            }

            return miniManufacturer;
        }

        // PUT: api/MiniManufacturer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiniManufacturer(Guid id, MiniManufacturer miniManufacturer)
        {
            if (id != miniManufacturer.Id)
            {
                return BadRequest();
            }

            _context.Entry(miniManufacturer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MiniManufacturerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MiniManufacturer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MiniManufacturer>> PostMiniManufacturer(MiniManufacturer miniManufacturer)
        {
            _context.MiniManufacturers.Add(miniManufacturer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMiniManufacturer", new { id = miniManufacturer.Id }, miniManufacturer);
        }

        // DELETE: api/MiniManufacturer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMiniManufacturer(Guid id)
        {
            var miniManufacturer = await _context.MiniManufacturers.FindAsync(id);
            if (miniManufacturer == null)
            {
                return NotFound();
            }

            _context.MiniManufacturers.Remove(miniManufacturer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MiniManufacturerExists(Guid id)
        {
            return _context.MiniManufacturers.Any(e => e.Id == id);
        }
    }
}
