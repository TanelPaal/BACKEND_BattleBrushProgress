using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
using App.Domain;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiniatureController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MiniatureController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Miniature
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Miniature>>> GetMiniatures()
        {
            return await _context.Miniatures.ToListAsync();
        }

        // GET: api/Miniature/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Miniature>> GetMiniature(Guid id)
        {
            var miniature = await _context.Miniatures.FindAsync(id);

            if (miniature == null)
            {
                return NotFound();
            }

            return miniature;
        }

        // PUT: api/Miniature/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiniature(Guid id, Miniature miniature)
        {
            if (id != miniature.Id)
            {
                return BadRequest();
            }

            _context.Entry(miniature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MiniatureExists(id))
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

        // POST: api/Miniature
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Miniature>> PostMiniature(Miniature miniature)
        {
            _context.Miniatures.Add(miniature);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMiniature", new { id = miniature.Id }, miniature);
        }

        // DELETE: api/Miniature/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMiniature(Guid id)
        {
            var miniature = await _context.Miniatures.FindAsync(id);
            if (miniature == null)
            {
                return NotFound();
            }

            _context.Miniatures.Remove(miniature);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MiniatureExists(Guid id)
        {
            return _context.Miniatures.Any(e => e.Id == id);
        }
    }
}
