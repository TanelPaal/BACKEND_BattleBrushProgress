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
    public class MiniPropertiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MiniPropertiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MiniProperties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MiniProperties>>> GetMiniProperties()
        {
            return await _context.MiniProperties.ToListAsync();
        }

        // GET: api/MiniProperties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MiniProperties>> GetMiniProperties(Guid id)
        {
            var miniProperties = await _context.MiniProperties.FindAsync(id);

            if (miniProperties == null)
            {
                return NotFound();
            }

            return miniProperties;
        }

        // PUT: api/MiniProperties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiniProperties(Guid id, MiniProperties miniProperties)
        {
            if (id != miniProperties.Id)
            {
                return BadRequest();
            }

            _context.Entry(miniProperties).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MiniPropertiesExists(id))
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

        // POST: api/MiniProperties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MiniProperties>> PostMiniProperties(MiniProperties miniProperties)
        {
            _context.MiniProperties.Add(miniProperties);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMiniProperties", new { id = miniProperties.Id }, miniProperties);
        }

        // DELETE: api/MiniProperties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMiniProperties(Guid id)
        {
            var miniProperties = await _context.MiniProperties.FindAsync(id);
            if (miniProperties == null)
            {
                return NotFound();
            }

            _context.MiniProperties.Remove(miniProperties);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MiniPropertiesExists(Guid id)
        {
            return _context.MiniProperties.Any(e => e.Id == id);
        }
    }
}
