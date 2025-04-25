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
public class MiniPropertiesController : Controller
{
    private readonly AppDbContext _context;

    public MiniPropertiesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: MiniProperties
    public async Task<IActionResult> Index()
    {
        return View(await _context.MiniProperties.ToListAsync());
    }

    // GET: MiniProperties/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var miniProperties = await _context.MiniProperties
            .FirstOrDefaultAsync(m => m.Id == id);
        if (miniProperties == null)
        {
            return NotFound();
        }

        return View(miniProperties);
    }

    // GET: MiniProperties/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: MiniProperties/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("PropertyName,PropertyDesc,Id")] MiniProperties miniProperties)
    {
        if (ModelState.IsValid)
        {
            miniProperties.Id = Guid.NewGuid();
            _context.Add(miniProperties);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(miniProperties);
    }

    // GET: MiniProperties/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var miniProperties = await _context.MiniProperties.FindAsync(id);
        if (miniProperties == null)
        {
            return NotFound();
        }
        return View(miniProperties);
    }

    // POST: MiniProperties/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("PropertyName,PropertyDesc,Id")] MiniProperties miniProperties)
    {
        if (id != miniProperties.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(miniProperties);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MiniPropertiesExists(miniProperties.Id))
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
        return View(miniProperties);
    }

    // GET: MiniProperties/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var miniProperties = await _context.MiniProperties
            .FirstOrDefaultAsync(m => m.Id == id);
        if (miniProperties == null)
        {
            return NotFound();
        }

        return View(miniProperties);
    }

    // POST: MiniProperties/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var miniProperties = await _context.MiniProperties.FindAsync(id);
        if (miniProperties != null)
        {
            _context.MiniProperties.Remove(miniProperties);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MiniPropertiesExists(Guid id)
    {
        return _context.MiniProperties.Any(e => e.Id == id);
    }
}