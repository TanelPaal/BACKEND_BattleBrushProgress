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
            var appDbContext = _context.MiniPaintSwatches
                .Include(m => m.MiniatureCollection)
                .Include(m => m.UserPaints)
                    .ThenInclude(up => up.Paint);
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
                .Include(m => m.MiniatureCollection)
                .Include(m => m.UserPaints)
                    .ThenInclude(up => up.Paint)
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
            ViewData["MiniatureCollectionId"] = new SelectList(_context.MiniatureCollections, "Id", "CollectionDesc");
            var userPaints = _context.UserPaints
                .Include(p => p.Paint)
                .Select(up => new { up.Id, Name = up.Paint != null ? up.Paint.Name : "Unknown" })
                .ToList();
            ViewData["UserPaintsId"] = new SelectList(userPaints, "Id", "Name");
            return View();
        }

        // POST: MiniPaintSwatch/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsageType,Notes,MiniatureCollectionId,UserPaintsId,Id")] MiniPaintSwatch miniPaintSwatch)
        {
            if (ModelState.IsValid)
            {
                miniPaintSwatch.Id = Guid.NewGuid();
                _context.Add(miniPaintSwatch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MiniatureCollectionId"] = new SelectList(_context.MiniatureCollections, "Id", "CollectionDesc", miniPaintSwatch.MiniatureCollectionId);
            var userPaints = _context.UserPaints
                .Include(p => p.Paint)
                .Select(up => new { up.Id, Name = up.Paint != null ? up.Paint.Name : "Unknown" })
                .ToList();
            ViewData["UserPaintsId"] = new SelectList(userPaints, "Id", "Name", miniPaintSwatch.UserPaintsId);
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
            ViewData["MiniatureCollectionId"] = new SelectList(_context.MiniatureCollections, "Id", "CollectionDesc", miniPaintSwatch.MiniatureCollectionId);
            var userPaints = _context.UserPaints
                .Include(p => p.Paint)
                .Select(up => new { up.Id, Name = up.Paint != null ? up.Paint.Name : "Unknown" })
                .ToList();
            ViewData["UserPaintsId"] = new SelectList(userPaints, "Id", "Name", miniPaintSwatch.UserPaintsId);
            return View(miniPaintSwatch);
        }

        // POST: MiniPaintSwatch/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("UsageType,Notes,MiniatureCollectionId,UserPaintsId,Id")] MiniPaintSwatch miniPaintSwatch)
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
            var userPaints = _context.UserPaints
                .Include(p => p.Paint)
                .Select(up => new { up.Id, Name = up.Paint != null ? up.Paint.Name : "Unknown" })
                .ToList();
            ViewData["UserPaintsId"] = new SelectList(userPaints, "Id", "Name", miniPaintSwatch.UserPaintsId);
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
                .Include(m => m.MiniatureCollection)
                .Include(m => m.UserPaints)
                    .ThenInclude(up => up.Paint)
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
