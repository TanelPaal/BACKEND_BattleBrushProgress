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
    public class PaintTypeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PaintTypeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PaintType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaintType>>> GetPaintTypes()
        {
            return await _context.PaintTypes.ToListAsync();
        }

        // GET: api/PaintType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaintType>> GetPaintType(Guid id)
        {
            var paintType = await _context.PaintTypes.FindAsync(id);

            if (paintType == null)
            {
                return NotFound();
            }

            return paintType;
        }

        // PUT: api/PaintType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaintType(Guid id, PaintType paintType)
        {
            if (id != paintType.Id)
            {
                return BadRequest();
            }

            _context.Entry(paintType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaintTypeExists(id))
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

        // POST: api/PaintType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaintType>> PostPaintType(PaintType paintType)
        {
            _context.PaintTypes.Add(paintType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaintType", new { id = paintType.Id }, paintType);
        }

        // DELETE: api/PaintType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaintType(Guid id)
        {
            var paintType = await _context.PaintTypes.FindAsync(id);
            if (paintType == null)
            {
                return NotFound();
            }

            _context.PaintTypes.Remove(paintType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaintTypeExists(Guid id)
        {
            return _context.PaintTypes.Any(e => e.Id == id);
        }
    }
}
