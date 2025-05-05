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
    public class PersonPaintsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PersonPaintsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PersonPaints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonPaints>>> GetPersonPaints()
        {
            return await _context.PersonPaints.ToListAsync();
        }

        // GET: api/PersonPaints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonPaints>> GetPersonPaints(Guid id)
        {
            var personPaints = await _context.PersonPaints.FindAsync(id);

            if (personPaints == null)
            {
                return NotFound();
            }

            return personPaints;
        }

        // PUT: api/PersonPaints/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonPaints(Guid id, PersonPaints personPaints)
        {
            if (id != personPaints.Id)
            {
                return BadRequest();
            }

            _context.Entry(personPaints).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonPaintsExists(id))
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

        // POST: api/PersonPaints
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonPaints>> PostPersonPaints(PersonPaints personPaints)
        {
            _context.PersonPaints.Add(personPaints);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonPaints", new { id = personPaints.Id }, personPaints);
        }

        // DELETE: api/PersonPaints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonPaints(Guid id)
        {
            var personPaints = await _context.PersonPaints.FindAsync(id);
            if (personPaints == null)
            {
                return NotFound();
            }

            _context.PersonPaints.Remove(personPaints);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonPaintsExists(Guid id)
        {
            return _context.PersonPaints.Any(e => e.Id == id);
        }
    }
}
