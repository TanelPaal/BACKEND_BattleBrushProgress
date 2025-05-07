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
    public class MiniFactionsController : Controller
    {
        private readonly AppDbContext _context;

        public MiniFactionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MiniFactions
        public async Task<IActionResult> Index()
        {
            return View(await _context.MiniFactions.ToListAsync());
        }

        // GET: MiniFactions/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miniFaction = await _context.MiniFactions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miniFaction == null)
            {
                return NotFound();
            }

            return View(miniFaction);
        }

        // GET: MiniFactions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MiniFactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FactionName,FactionDesc,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt,SysNotes")] MiniFaction miniFaction)
        {
            if (ModelState.IsValid)
            {
                miniFaction.Id = Guid.NewGuid();
                _context.Add(miniFaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(miniFaction);
        }

        // GET: MiniFactions/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miniFaction = await _context.MiniFactions.FindAsync(id);
            if (miniFaction == null)
            {
                return NotFound();
            }
            return View(miniFaction);
        }

        // POST: MiniFactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FactionName,FactionDesc,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt,SysNotes")] MiniFaction miniFaction)
        {
            if (id != miniFaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(miniFaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiniFactionExists(miniFaction.Id))
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
            return View(miniFaction);
        }

        // GET: MiniFactions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miniFaction = await _context.MiniFactions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miniFaction == null)
            {
                return NotFound();
            }

            return View(miniFaction);
        }

        // POST: MiniFactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var miniFaction = await _context.MiniFactions.FindAsync(id);
            if (miniFaction != null)
            {
                _context.MiniFactions.Remove(miniFaction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiniFactionExists(Guid id)
        {
            return _context.MiniFactions.Any(e => e.Id == id);
        }
    }
}
