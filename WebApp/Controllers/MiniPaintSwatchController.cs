using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
using App.Domain;

namespace WebApp.Controllers
{
    public class MiniPaintSwatchController : Controller
    {
        private readonly AppDbContext _context;

        public MiniPaintSwatchController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MiniPaintSwatch
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.MiniPaintSwatches.Include(m => m.AppUser).Include(m => m.MiniatureCollection).Include(m => m.PersonPaints);
            return View(await appDbContext.ToListAsync());
        }

        // GET: MiniPaintSwatch/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miniPaintSwatch = await _context.MiniPaintSwatches
                .Include(m => m.AppUser)
                .Include(m => m.MiniatureCollection)
                .Include(m => m.PersonPaints)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miniPaintSwatch == null)
            {
                return NotFound();
            }

            return View(miniPaintSwatch);
        }

        // GET: MiniPaintSwatch/Create
        public IActionResult Create()
        {
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["MiniatureCollectionId"] = new SelectList(_context.MiniatureCollections, "Id", "CollectionDesc");
            ViewData["PersonPaintsId"] = new SelectList(_context.PersonPaints, "Id", "Id");
            return View();
        }

        // POST: MiniPaintSwatch/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsageType,Notes,MiniatureCollectionId,PersonPaintsId,AppUserId,Id")] MiniPaintSwatch miniPaintSwatch)
        {
            if (ModelState.IsValid)
            {
                miniPaintSwatch.Id = Guid.NewGuid();
                _context.Add(miniPaintSwatch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", miniPaintSwatch.AppUserId);
            ViewData["MiniatureCollectionId"] = new SelectList(_context.MiniatureCollections, "Id", "CollectionDesc", miniPaintSwatch.MiniatureCollectionId);
            ViewData["PersonPaintsId"] = new SelectList(_context.PersonPaints, "Id", "Id", miniPaintSwatch.PersonPaintsId);
            return View(miniPaintSwatch);
        }

        // GET: MiniPaintSwatch/Edit/5
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
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", miniPaintSwatch.AppUserId);
            ViewData["MiniatureCollectionId"] = new SelectList(_context.MiniatureCollections, "Id", "CollectionDesc", miniPaintSwatch.MiniatureCollectionId);
            ViewData["PersonPaintsId"] = new SelectList(_context.PersonPaints, "Id", "Id", miniPaintSwatch.PersonPaintsId);
            return View(miniPaintSwatch);
        }

        // POST: MiniPaintSwatch/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("UsageType,Notes,MiniatureCollectionId,PersonPaintsId,AppUserId,Id")] MiniPaintSwatch miniPaintSwatch)
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
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", miniPaintSwatch.AppUserId);
            ViewData["MiniatureCollectionId"] = new SelectList(_context.MiniatureCollections, "Id", "CollectionDesc", miniPaintSwatch.MiniatureCollectionId);
            ViewData["PersonPaintsId"] = new SelectList(_context.PersonPaints, "Id", "Id", miniPaintSwatch.PersonPaintsId);
            return View(miniPaintSwatch);
        }

        // GET: MiniPaintSwatch/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miniPaintSwatch = await _context.MiniPaintSwatches
                .Include(m => m.AppUser)
                .Include(m => m.MiniatureCollection)
                .Include(m => m.PersonPaints)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miniPaintSwatch == null)
            {
                return NotFound();
            }

            return View(miniPaintSwatch);
        }

        // POST: MiniPaintSwatch/Delete/5
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
