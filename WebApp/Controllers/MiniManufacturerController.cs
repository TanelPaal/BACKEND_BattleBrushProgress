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
public class MiniManufacturerController : Controller
{
    private readonly AppDbContext _context;

    public MiniManufacturerController(AppDbContext context)
    {
        _context = context;
    }

    // GET: MiniManufacturer
    public async Task<IActionResult> Index()
    {
        return View(await _context.MiniManufacturers.ToListAsync());
    }

    // GET: MiniManufacturer/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var miniManufacturer = await _context.MiniManufacturers
            .FirstOrDefaultAsync(m => m.Id == id);
        if (miniManufacturer == null)
        {
            return NotFound();
        }

        return View(miniManufacturer);
    }

    // GET: MiniManufacturer/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: MiniManufacturer/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ManufacturerName,HeadquartersLocation,ContactEmail,ContactPhone,Id")] MiniManufacturer miniManufacturer)
    {
        if (ModelState.IsValid)
        {
            miniManufacturer.Id = Guid.NewGuid();
            _context.Add(miniManufacturer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(miniManufacturer);
    }

    // GET: MiniManufacturer/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var miniManufacturer = await _context.MiniManufacturers.FindAsync(id);
        if (miniManufacturer == null)
        {
            return NotFound();
        }
        return View(miniManufacturer);
    }

    // POST: MiniManufacturer/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("ManufacturerName,HeadquartersLocation,ContactEmail,ContactPhone,Id")] MiniManufacturer miniManufacturer)
    {
        if (id != miniManufacturer.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(miniManufacturer);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MiniManufacturerExists(miniManufacturer.Id))
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
        return View(miniManufacturer);
    }

    // GET: MiniManufacturer/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var miniManufacturer = await _context.MiniManufacturers
            .FirstOrDefaultAsync(m => m.Id == id);
        if (miniManufacturer == null)
        {
            return NotFound();
        }

        return View(miniManufacturer);
    }

    // POST: MiniManufacturer/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var miniManufacturer = await _context.MiniManufacturers.FindAsync(id);
        if (miniManufacturer != null)
        {
            _context.MiniManufacturers.Remove(miniManufacturer);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MiniManufacturerExists(Guid id)
    {
        return _context.MiniManufacturers.Any(e => e.Id == id);
    }
}