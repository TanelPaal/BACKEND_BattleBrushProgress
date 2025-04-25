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

namespace WebApp.Controllers;

[Authorize]
public class PaintTypeController : Controller
{
    private readonly AppDbContext _context;

    public PaintTypeController(AppDbContext context)
    {
        _context = context;
    }

    // GET: PaintType
    public async Task<IActionResult> Index()
    {
        return View(await _context.PaintTypes.ToListAsync());
    }

    // GET: PaintType/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var paintType = await _context.PaintTypes
            .FirstOrDefaultAsync(m => m.Id == id);
        if (paintType == null)
        {
            return NotFound();
        }

        return View(paintType);
    }

    // GET: PaintType/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PaintType/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,Description,Id")] PaintType paintType)
    {
        if (ModelState.IsValid)
        {
            paintType.Id = Guid.NewGuid();
            _context.Add(paintType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(paintType);
    }

    // GET: PaintType/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var paintType = await _context.PaintTypes.FindAsync(id);
        if (paintType == null)
        {
            return NotFound();
        }
        return View(paintType);
    }

    // POST: PaintType/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("Name,Description,Id")] PaintType paintType)
    {
        if (id != paintType.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(paintType);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaintTypeExists(paintType.Id))
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
        return View(paintType);
    }

    // GET: PaintType/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var paintType = await _context.PaintTypes
            .FirstOrDefaultAsync(m => m.Id == id);
        if (paintType == null)
        {
            return NotFound();
        }

        return View(paintType);
    }

    // POST: PaintType/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var paintType = await _context.PaintTypes.FindAsync(id);
        if (paintType != null)
        {
            _context.PaintTypes.Remove(paintType);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PaintTypeExists(Guid id)
    {
        return _context.PaintTypes.Any(e => e.Id == id);
    }
}