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
    public class MiniStateController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MiniStateController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MiniState
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MiniState>>> GetMiniStates()
        {
            return await _context.MiniStates.ToListAsync();
        }

        // GET: api/MiniState/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MiniState>> GetMiniState(Guid id)
        {
            var miniState = await _context.MiniStates.FindAsync(id);

            if (miniState == null)
            {
                return NotFound();
            }

            return miniState;
        }

        // PUT: api/MiniState/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiniState(Guid id, MiniState miniState)
        {
            if (id != miniState.Id)
            {
                return BadRequest();
            }

            _context.Entry(miniState).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MiniStateExists(id))
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

        // POST: api/MiniState
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MiniState>> PostMiniState(MiniState miniState)
        {
            _context.MiniStates.Add(miniState);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMiniState", new { id = miniState.Id }, miniState);
        }

        // DELETE: api/MiniState/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMiniState(Guid id)
        {
            var miniState = await _context.MiniStates.FindAsync(id);
            if (miniState == null)
            {
                return NotFound();
            }

            _context.MiniStates.Remove(miniState);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MiniStateExists(Guid id)
        {
            return _context.MiniStates.Any(e => e.Id == id);
        }
    }
}
