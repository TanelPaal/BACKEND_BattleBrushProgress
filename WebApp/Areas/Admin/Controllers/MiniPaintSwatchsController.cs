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
    public class MiniPaintSwatchsController : Controller
    {
        private readonly AppDbContext _context;

        public MiniPaintSwatchsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MiniPaintSwatchs
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.MiniPaintSwatches
                .Include(m => m.MiniatureCollection)
                .Include(m => m.PersonPaints)
                .Include(m => m.User);
            return View(await appDbContext.ToListAsync());
        }

        // GET: MiniPaintSwatchs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miniPaintSwatch = await _context.MiniPaintSwatches
                .Include(m => m.MiniatureCollection)
                .Include(m => m.PersonPaints)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miniPaintSwatch == null)
            {
                return NotFound();
            }

            return View(miniPaintSwatch);
        }

        // GET: MiniPaintSwatchs/Create
        public IActionResult Create()
        {
            ViewData["MiniatureCollectionId"] = new SelectList(_context.MiniatureCollections, "Id", "CollectionDesc");
            ViewData["PersonPaintsId"] = new SelectList(_context.PersonPaints, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: MiniPaintSwatchs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsageType,Notes,MiniatureCollectionId,PersonPaintsId,UserId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt,SysNotes")] MiniPaintSwatch miniPaintSwatch)
        {
            if (ModelState.IsValid)
            {
                miniPaintSwatch.Id = Guid.NewGuid();
                _context.Add(miniPaintSwatch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MiniatureCollectionId"] = new SelectList(_context.MiniatureCollections, "Id", "CollectionDesc", miniPaintSwatch.MiniatureCollectionId);
            ViewData["PersonPaintsId"] = new SelectList(_context.PersonPaints, "Id", "Id", miniPaintSwatch.PersonPaintsId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", miniPaintSwatch.UserId);
            return View(miniPaintSwatch);
        }

        // GET: MiniPaintSwatchs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miniPaintSwatch = await _context.MiniPaintSwatches.FindAsync(id);
            if (miniPaintSwatch == null)
            {
                return NotFound();
            }
            ViewData["MiniatureCollectionId"] = new SelectList(_context.MiniatureCollections, "Id", "CollectionDesc", miniPaintSwatch.MiniatureCollectionId);
            ViewData["PersonPaintsId"] = new SelectList(_context.PersonPaints, "Id", "Id", miniPaintSwatch.PersonPaintsId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", miniPaintSwatch.UserId);
            return View(miniPaintSwatch);
        }

        // POST: MiniPaintSwatchs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("UsageType,Notes,MiniatureCollectionId,PersonPaintsId,UserId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt,SysNotes")] MiniPaintSwatch miniPaintSwatch)
        {
            if (id != miniPaintSwatch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(miniPaintSwatch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiniPaintSwatchExists(miniPaintSwatch.Id))
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
            ViewData["MiniatureCollectionId"] = new SelectList(_context.MiniatureCollections, "Id", "CollectionDesc", miniPaintSwatch.MiniatureCollectionId);
            ViewData["PersonPaintsId"] = new SelectList(_context.PersonPaints, "Id", "Id", miniPaintSwatch.PersonPaintsId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", miniPaintSwatch.UserId);
            return View(miniPaintSwatch);
        }

        // GET: MiniPaintSwatchs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miniPaintSwatch = await _context.MiniPaintSwatches
                .Include(m => m.MiniatureCollection)
                .Include(m => m.PersonPaints)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miniPaintSwatch == null)
            {
                return NotFound();
            }

            return View(miniPaintSwatch);
        }

        // POST: MiniPaintSwatchs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var miniPaintSwatch = await _context.MiniPaintSwatches.FindAsync(id);
            if (miniPaintSwatch != null)
            {
                _context.MiniPaintSwatches.Remove(miniPaintSwatch);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiniPaintSwatchExists(Guid id)
        {
            return _context.MiniPaintSwatches.Any(e => e.Id == id);
        }
    }
}
