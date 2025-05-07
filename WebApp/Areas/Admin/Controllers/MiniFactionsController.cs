using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
using App.Domain;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Areas.Admin.Controllers
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

        public async Task<IActionResult> Index()
        {
            return View(await _context.MiniFactions.ToListAsync());
        }

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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt,SysNotes")] MiniFaction miniFaction)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt,SysNotes")] MiniFaction miniFaction)
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