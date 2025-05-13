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
    public class MiniaturesController : Controller
    {
        private readonly AppDbContext _context;

        public MiniaturesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Miniatures
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Miniatures
                .Include(m => m.MiniFaction)
                .Include(m => m.MiniManufacturer)
                .Include(m => m.MiniProperties);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Miniatures/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miniature = await _context.Miniatures
                .Include(m => m.MiniFaction)
                .Include(m => m.MiniManufacturer)
                .Include(m => m.MiniProperties)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miniature == null)
            {
                return NotFound();
            }

            return View(miniature);
        }

        // GET: Miniatures/Create
        public IActionResult Create()
        {
            ViewData["MiniFactionId"] = new SelectList(_context.MiniFactions, "Id", "FactionDesc");
            ViewData["MiniManufacturerId"] = new SelectList(_context.MiniManufacturers, "Id", "ManufacturerName");
            ViewData["MiniPropertiesId"] = new SelectList(_context.MiniProperties, "Id", "PropertyName");
            return View();
        }

        // POST: Miniatures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            ViewData["MiniFactionId"] = new SelectList(_context.MiniFactions, "Id", "FactionDesc", miniature.MiniFactionId);
            ViewData["MiniManufacturerId"] = new SelectList(_context.MiniManufacturers, "Id", "ManufacturerName", miniature.MiniManufacturerId);
            ViewData["MiniPropertiesId"] = new SelectList(_context.MiniProperties, "Id", "PropertyName", miniature.MiniPropertiesId);
            return View(miniature);
        }

        // GET: Miniatures/Edit/5
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
            ViewData["MiniFactionId"] = new SelectList(_context.MiniFactions, "Id", "FactionDesc", miniature.MiniFactionId);
            ViewData["MiniManufacturerId"] = new SelectList(_context.MiniManufacturers, "Id", "ManufacturerName", miniature.MiniManufacturerId);
            ViewData["MiniPropertiesId"] = new SelectList(_context.MiniProperties, "Id", "PropertyName", miniature.MiniPropertiesId);
            return View(miniature);
        }

        // POST: Miniatures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            ViewData["MiniFactionId"] = new SelectList(_context.MiniFactions, "Id", "FactionDesc", miniature.MiniFactionId);
            ViewData["MiniManufacturerId"] = new SelectList(_context.MiniManufacturers, "Id", "ManufacturerName", miniature.MiniManufacturerId);
            ViewData["MiniPropertiesId"] = new SelectList(_context.MiniProperties, "Id", "PropertyName", miniature.MiniPropertiesId);
            return View(miniature);
        }

        // GET: Miniatures/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miniature = await _context.Miniatures
                .Include(m => m.MiniFaction)
                .Include(m => m.MiniManufacturer)
                .Include(m => m.MiniProperties)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miniature == null)
            {
                return NotFound();
            }

            return View(miniature);
        }

        // POST: Miniatures/Delete/5
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
