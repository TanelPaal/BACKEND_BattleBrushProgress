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
    public class MiniFactionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MiniFactionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MiniFaction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MiniFaction>>> GetMiniFactions()
        {
            return await _context.MiniFactions.ToListAsync();
        }

        // GET: api/MiniFaction/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MiniFaction>> GetMiniFaction(Guid id)
        {
            var miniFaction = await _context.MiniFactions.FindAsync(id);

            if (miniFaction == null)
            {
                return NotFound();
            }

            return miniFaction;
        }

        // PUT: api/MiniFaction/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiniFaction(Guid id, MiniFaction miniFaction)
        {
            if (id != miniFaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(miniFaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MiniFactionExists(id))
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

        // POST: api/MiniFaction
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MiniFaction>> PostMiniFaction(MiniFaction miniFaction)
        {
            _context.MiniFactions.Add(miniFaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMiniFaction", new { id = miniFaction.Id }, miniFaction);
        }

        // DELETE: api/MiniFaction/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMiniFaction(Guid id)
        {
            var miniFaction = await _context.MiniFactions.FindAsync(id);
            if (miniFaction == null)
            {
                return NotFound();
            }

            _context.MiniFactions.Remove(miniFaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MiniFactionExists(Guid id)
        {
            return _context.MiniFactions.Any(e => e.Id == id);
        }
    }
}
