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
    public class PaintLineController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PaintLineController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PaintLine
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaintLine>>> GetPaintLines()
        {
            return await _context.PaintLines.ToListAsync();
        }

        // GET: api/PaintLine/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaintLine>> GetPaintLine(Guid id)
        {
            var paintLine = await _context.PaintLines.FindAsync(id);

            if (paintLine == null)
            {
                return NotFound();
            }

            return paintLine;
        }

        // PUT: api/PaintLine/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaintLine(Guid id, PaintLine paintLine)
        {
            if (id != paintLine.Id)
            {
                return BadRequest();
            }

            _context.Entry(paintLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaintLineExists(id))
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

        // POST: api/PaintLine
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaintLine>> PostPaintLine(PaintLine paintLine)
        {
            _context.PaintLines.Add(paintLine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaintLine", new { id = paintLine.Id }, paintLine);
        }

        // DELETE: api/PaintLine/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaintLine(Guid id)
        {
            var paintLine = await _context.PaintLines.FindAsync(id);
            if (paintLine == null)
            {
                return NotFound();
            }

            _context.PaintLines.Remove(paintLine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaintLineExists(Guid id)
        {
            return _context.PaintLines.Any(e => e.Id == id);
        }
    }
}
