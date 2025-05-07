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
    public class MiniaturesController : Controller
    {
        private readonly AppDbContext _context;

        public MiniaturesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Miniatures
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Miniatures
                .Include(m => m.MiniFaction)
                .Include(m => m.MiniProperties)
                .Include(m => m.MiniManufacturer);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/Miniatures/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miniature = await _context.Miniatures
                .Include(m => m.MiniFaction)
                .Include(m => m.MiniProperties)
                .Include(m => m.MiniManufacturer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miniature == null)
            {
                return NotFound();
            }

            return View(miniature);
        }

        // GET: Admin/Miniatures/Create
        public IActionResult Create()
        {
            ViewData["MiniFactionId"] = new SelectList(_context.MiniFactions, "Id", "Name");
            ViewData["MiniPropertiesId"] = new SelectList(_context.MiniProperties, "Id", "Name");
            ViewData["MiniManufacturerId"] = new SelectList(_context.MiniManufacturers, "Id", "Name");
            return View();
        }

        // POST: Admin/Miniatures/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MiniName,MiniDesc,MiniFactionId,MiniPropertiesId,MiniManufacturerId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt,SysNotes")] Miniature miniature)
        {
            if (ModelState.IsValid)
            {
                miniature.Id = Guid.NewGuid();
                _context.Add(miniature);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MiniFactionId"] = new SelectList(_context.MiniFactions, "Id", "Name", miniature.MiniFactionId);
            ViewData["MiniPropertiesId"] = new SelectList(_context.MiniProperties, "Id", "Name", miniature.MiniPropertiesId);
            ViewData["MiniManufacturerId"] = new SelectList(_context.MiniManufacturers, "Id", "Name", miniature.MiniManufacturerId);
            return View(miniature);
        }

        // GET: Admin/Miniatures/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miniature = await _context.Miniatures.FindAsync(id);
            if (miniature == null)
            {
                return NotFound();
            }
            ViewData["MiniFactionId"] = new SelectList(_context.MiniFactions, "Id", "Name", miniature.MiniFactionId);
            ViewData["MiniPropertiesId"] = new SelectList(_context.MiniProperties, "Id", "Name", miniature.MiniPropertiesId);
            ViewData["MiniManufacturerId"] = new SelectList(_context.MiniManufacturers, "Id", "Name", miniature.MiniManufacturerId);
            return View(miniature);
        }

        // POST: Admin/Miniatures/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("MiniName,MiniDesc,MiniFactionId,MiniPropertiesId,MiniManufacturerId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt,SysNotes")] Miniature miniature)
        {
            if (id != miniature.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(miniature);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiniatureExists(miniature.Id))
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
            ViewData["MiniFactionId"] = new SelectList(_context.MiniFactions, "Id", "Name", miniature.MiniFactionId);
            ViewData["MiniPropertiesId"] = new SelectList(_context.MiniProperties, "Id", "Name", miniature.MiniPropertiesId);
            ViewData["MiniManufacturerId"] = new SelectList(_context.MiniManufacturers, "Id", "Name", miniature.MiniManufacturerId);
            return View(miniature);
        }

        // GET: Admin/Miniatures/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miniature = await _context.Miniatures
                .Include(m => m.MiniFaction)
                .Include(m => m.MiniProperties)
                .Include(m => m.MiniManufacturer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miniature == null)
            {
                return NotFound();
            }

            return View(miniature);
        }

        // POST: Admin/Miniatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var miniature = await _context.Miniatures.FindAsync(id);
            if (miniature != null)
            {
                _context.Miniatures.Remove(miniature);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiniatureExists(Guid id)
        {
            return _context.Miniatures.Any(e => e.Id == id);
        }
    }
}