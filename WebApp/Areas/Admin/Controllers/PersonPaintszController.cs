using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
using App.Domain;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Areas_Admin_Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class PersonPaintszController : Controller
    {
        private readonly AppDbContext _context;

        public PersonPaintszController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PersonPaintsz
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PersonPaints
                .Include(p => p.Paint)
                .Include(p => p.Person)
                .Include(p => p.User);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PersonPaintsz/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personPaints = await _context.PersonPaints
                .Include(p => p.Paint)
                .Include(p => p.Person)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personPaints == null)
            {
                return NotFound();
            }

            return View(personPaints);
        }

        // GET: PersonPaintsz/Create
        public IActionResult Create()
        {
            ViewData["PaintId"] = new SelectList(_context.Paints, "Id", "Name");
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "PersonName");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: PersonPaintsz/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Quantity,AcquisitionDate,PersonId,PaintId,UserId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt,SysNotes")] PersonPaints personPaints)
        {
            if (ModelState.IsValid)
            {
                personPaints.Id = Guid.NewGuid();
                _context.Add(personPaints);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaintId"] = new SelectList(_context.Paints, "Id", "Name", personPaints.PaintId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "PersonName", personPaints.PersonId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", personPaints.UserId);
            return View(personPaints);
        }

        // GET: PersonPaintsz/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personPaints = await _context.PersonPaints.FindAsync(id);
            if (personPaints == null)
            {
                return NotFound();
            }
            ViewData["PaintId"] = new SelectList(_context.Paints, "Id", "Name", personPaints.PaintId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "PersonName", personPaints.PersonId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", personPaints.UserId);
            return View(personPaints);
        }

        // POST: PersonPaintsz/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Quantity,AcquisitionDate,PersonId,PaintId,UserId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt,SysNotes")] PersonPaints personPaints)
        {
            if (id != personPaints.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personPaints);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonPaintsExists(personPaints.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaintId"] = new SelectList(_context.Paints, "Id", "Name", personPaints.PaintId);
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "PersonName", personPaints.PersonId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", personPaints.UserId);
            return View(personPaints);
        }

        // GET: PersonPaintsz/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personPaints = await _context.PersonPaints
                .Include(p => p.Paint)
                .Include(p => p.Person)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personPaints == null)
            {
                return NotFound();
            }

            return View(personPaints);
        }

        // POST: PersonPaintsz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var personPaints = await _context.PersonPaints.FindAsync(id);
            if (personPaints != null)
            {
                _context.PersonPaints.Remove(personPaints);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonPaintsExists(Guid id)
        {
            return _context.PersonPaints.Any(e => e.Id == id);
        }
    }
}
