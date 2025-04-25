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
public class MiniFactionController : Controller
{
    private readonly AppDbContext _context;

    public MiniFactionController(AppDbContext context)
    {
        _context = context;
    }

    // GET: MiniFaction
    public async Task<IActionResult> Index()
    {
        return View(await _context.MiniFactions.ToListAsync());
    }

    // GET: MiniFaction/Details/5
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

    // GET: MiniFaction/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: MiniFaction/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("FactionName,FactionDesc,Id")] MiniFaction miniFaction)
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

    // GET: MiniFaction/Edit/5
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

    // POST: MiniFaction/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("FactionName,FactionDesc,Id")] MiniFaction miniFaction)
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

    // GET: MiniFaction/Delete/5
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

    // POST: MiniFaction/Delete/5
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