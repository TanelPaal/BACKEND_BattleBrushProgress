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
    public class PaintController : Controller
    {
        private readonly AppDbContext _context;

        public PaintController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Paint
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Paints.Include(p => p.Brand).Include(p => p.PaintType);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Paint/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paint = await _context.Paints
                .Include(p => p.Brand)
                .Include(p => p.PaintType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paint == null)
            {
                return NotFound();
            }

            return View(paint);
        }

        // GET: Paint/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "BrandName");
            ViewData["PaintTypeId"] = new SelectList(_context.PaintTypes, "Id", "Name");
            return View();
        }

        // POST: Paint/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,HexCode,UPC,BrandId,PaintTypeId,Id")] Paint paint)
        {
            if (ModelState.IsValid)
            {
                paint.Id = Guid.NewGuid();
                _context.Add(paint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "BrandName", paint.BrandId);
            ViewData["PaintTypeId"] = new SelectList(_context.PaintTypes, "Id", "Name", paint.PaintTypeId);
            return View(paint);
        }

        // GET: Paint/Edit/5
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "BrandName", paint.BrandId);
            ViewData["PaintTypeId"] = new SelectList(_context.PaintTypes, "Id", "Name", paint.PaintTypeId);
            return View(paint);
        }

        // POST: Paint/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,HexCode,UPC,BrandId,PaintTypeId,Id")] Paint paint)
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "BrandName", paint.BrandId);
            ViewData["PaintTypeId"] = new SelectList(_context.PaintTypes, "Id", "Name", paint.PaintTypeId);
            return View(paint);
        }

        // GET: Paint/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paint = await _context.Paints
                .Include(p => p.Brand)
                .Include(p => p.PaintType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paint == null)
            {
                return NotFound();
            }

            return View(paint);
        }

        // POST: Paint/Delete/5
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
