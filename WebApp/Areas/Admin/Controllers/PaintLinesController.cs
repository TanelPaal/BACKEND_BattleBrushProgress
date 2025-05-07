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
    internal class PaintLinesController : Controller
    {
        private readonly AppDbContext _context;

        public PaintLinesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PaintLines
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PaintLines.Include(p => p.Brand);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PaintLines/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paintLine = await _context.PaintLines
                .Include(p => p.Brand)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paintLine == null)
            {
                return NotFound();
            }

            return View(paintLine);
        }

        // GET: PaintLines/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "BrandName");
            return View();
        }

        // POST: PaintLines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaintLineName,Description,BrandId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt,SysNotes")] PaintLine paintLine)
        {
            if (ModelState.IsValid)
            {
                paintLine.Id = Guid.NewGuid();
                _context.Add(paintLine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "BrandName", paintLine.BrandId);
            return View(paintLine);
        }

        // GET: PaintLines/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paintLine = await _context.PaintLines.FindAsync(id);
            if (paintLine == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "BrandName", paintLine.BrandId);
            return View(paintLine);
        }

        // POST: PaintLines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PaintLineName,Description,BrandId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt,SysNotes")] PaintLine paintLine)
        {
            if (id != paintLine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paintLine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaintLineExists(paintLine.Id))
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "BrandName", paintLine.BrandId);
            return View(paintLine);
        }

        // GET: PaintLines/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paintLine = await _context.PaintLines
                .Include(p => p.Brand)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paintLine == null)
            {
                return NotFound();
            }

            return View(paintLine);
        }

        // POST: PaintLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var paintLine = await _context.PaintLines.FindAsync(id);
            if (paintLine != null)
            {
                _context.PaintLines.Remove(paintLine);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaintLineExists(Guid id)
        {
            return _context.PaintLines.Any(e => e.Id == id);
        }
    }
}
