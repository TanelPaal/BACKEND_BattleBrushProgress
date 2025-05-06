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
    public class MiniatureCollectionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MiniatureCollectionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MiniatureCollection
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MiniatureCollection>>> GetMiniatureCollections()
        {
            return await _context.MiniatureCollections.ToListAsync();
        }

        // GET: api/MiniatureCollection/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MiniatureCollection>> GetMiniatureCollection(Guid id)
        {
            var miniatureCollection = await _context.MiniatureCollections.FindAsync(id);

            if (miniatureCollection == null)
            {
                return NotFound();
            }

            return miniatureCollection;
        }

        // PUT: api/MiniatureCollection/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiniatureCollection(Guid id, MiniatureCollection miniatureCollection)
        {
            if (id != miniatureCollection.Id)
            {
                return BadRequest();
            }

            _context.Entry(miniatureCollection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MiniatureCollectionExists(id))
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

        // POST: api/MiniatureCollection
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MiniatureCollection>> PostMiniatureCollection(MiniatureCollection miniatureCollection)
        {
            _context.MiniatureCollections.Add(miniatureCollection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMiniatureCollection", new { id = miniatureCollection.Id }, miniatureCollection);
        }

        // DELETE: api/MiniatureCollection/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMiniatureCollection(Guid id)
        {
            var miniatureCollection = await _context.MiniatureCollections.FindAsync(id);
            if (miniatureCollection == null)
            {
                return NotFound();
            }

            _context.MiniatureCollections.Remove(miniatureCollection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MiniatureCollectionExists(Guid id)
        {
            return _context.MiniatureCollections.Any(e => e.Id == id);
        }
    }
}
