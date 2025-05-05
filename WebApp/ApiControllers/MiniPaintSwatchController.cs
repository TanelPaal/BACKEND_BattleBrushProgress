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
    public class MiniPaintSwatchController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MiniPaintSwatchController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MiniPaintSwatch
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MiniPaintSwatch>>> GetMiniPaintSwatches()
        {
            return await _context.MiniPaintSwatches.ToListAsync();
        }

        // GET: api/MiniPaintSwatch/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MiniPaintSwatch>> GetMiniPaintSwatch(Guid id)
        {
            var miniPaintSwatch = await _context.MiniPaintSwatches.FindAsync(id);

            if (miniPaintSwatch == null)
            {
                return NotFound();
            }

            return miniPaintSwatch;
        }

        // PUT: api/MiniPaintSwatch/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiniPaintSwatch(Guid id, MiniPaintSwatch miniPaintSwatch)
        {
            if (id != miniPaintSwatch.Id)
            {
                return BadRequest();
            }

            _context.Entry(miniPaintSwatch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MiniPaintSwatchExists(id))
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

        // POST: api/MiniPaintSwatch
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MiniPaintSwatch>> PostMiniPaintSwatch(MiniPaintSwatch miniPaintSwatch)
        {
            _context.MiniPaintSwatches.Add(miniPaintSwatch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMiniPaintSwatch", new { id = miniPaintSwatch.Id }, miniPaintSwatch);
        }

        // DELETE: api/MiniPaintSwatch/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMiniPaintSwatch(Guid id)
        {
            var miniPaintSwatch = await _context.MiniPaintSwatches.FindAsync(id);
            if (miniPaintSwatch == null)
            {
                return NotFound();
            }

            _context.MiniPaintSwatches.Remove(miniPaintSwatch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MiniPaintSwatchExists(Guid id)
        {
            return _context.MiniPaintSwatches.Any(e => e.Id == id);
        }
    }
}
