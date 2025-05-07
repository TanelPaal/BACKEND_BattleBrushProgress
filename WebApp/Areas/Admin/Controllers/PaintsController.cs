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

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class PaintsController : Controller
    {
        private readonly AppDbContext _context;

        public PaintsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Paints
                .Include(p => p.PaintLine)
                .Include(p => p.PaintType);
            return View(await appDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paint = await _context.Paints
                .Include(p => p.PaintLine)
                .Include(p => p.PaintType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paint == null)
            {
                return NotFound();
            }

            return View(paint);
        }

        public IActionResult Create()
        {
            ViewData["PaintLineId"] = new SelectList(_context.PaintLines, "Id", "Name");
            ViewData["PaintTypeId"] = new SelectList(_context.PaintTypes, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaintName,PaintHex,PaintLineId,PaintTypeId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt,SysNotes")] Paint paint)
        {
            if (ModelState.IsValid)
            {
                paint.Id = Guid.NewGuid();
                _context.Add(paint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaintLineId"] = new SelectList(_context.PaintLines, "Id", "Name", paint.PaintLineId);
            ViewData["PaintTypeId"] = new SelectList(_context.PaintTypes, "Id", "Name", paint.PaintTypeId);
            return View(paint);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paint = await _context.Paints.FindAsync(id);
            if (paint == null)
            {
                return NotFound();
            }
            ViewData["PaintLineId"] = new SelectList(_context.PaintLines, "Id", "Name", paint.PaintLineId);
            ViewData["PaintTypeId"] = new SelectList(_context.PaintTypes, "Id", "Name", paint.PaintTypeId);
            return View(paint);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PaintName,PaintHex,PaintLineId,PaintTypeId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt,SysNotes")] Paint paint)
        {
            if (id != paint.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaintExists(paint.Id))
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
            ViewData["PaintLineId"] = new SelectList(_context.PaintLines, "Id", "Name", paint.PaintLineId);
            ViewData["PaintTypeId"] = new SelectList(_context.PaintTypes, "Id", "Name", paint.PaintTypeId);
            return View(paint);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paint = await _context.Paints
                .Include(p => p.PaintLine)
                .Include(p => p.PaintType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paint == null)
            {
                return NotFound();
            }

            return View(paint);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var paint = await _context.Paints.FindAsync(id);
            if (paint != null)
            {
                _context.Paints.Remove(paint);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaintExists(Guid id)
        {
            return _context.Paints.Any(e => e.Id == id);
        }
    }
}