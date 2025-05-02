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
public class PersonPaintsController : Controller
{
    private readonly AppDbContext _context;

    public PersonPaintsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: PersonPaints
    public async Task<IActionResult> Index()
    {
        var appDbContext = _context.PersonPaints.Include(p => p.User).Include(p => p.Paint).Include(p => p.Person);
        return View(await appDbContext.ToListAsync());
    }

    // GET: PersonPaints/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var personPaints = await _context.PersonPaints
            .Include(p => p.User)
            .Include(p => p.Paint)
            .Include(p => p.Person)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (personPaints == null)
        {
            return NotFound();
        }

        return View(personPaints);
    }

    // GET: PersonPaints/Create
    public IActionResult Create()
    {
        ViewData["PaintId"] = new SelectList(_context.Paints, "Id", "HexCode");
        ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "PersonName");
        return View();
    }

    // POST: PersonPaints/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Quantity,AcquisitionDate,PersonId,PaintId,Id")] PersonPaints personPaints)
    {
        if (ModelState.IsValid)
        {
            personPaints.Id = Guid.NewGuid();
            personPaints.UserId = Guid.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!);
            _context.Add(personPaints);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["PaintId"] = new SelectList(_context.Paints, "Id", "HexCode", personPaints.PaintId);
        ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "PersonName", personPaints.PersonId);
        return View(personPaints);
    }

    // GET: PersonPaints/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var personPaints = await _context.PersonPaints.FindAsync(id);
        if (personPaints == null)
        {
            return NotFound();
        }
        ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", personPaints.UserId);
        ViewData["PaintId"] = new SelectList(_context.Paints, "Id", "HexCode", personPaints.PaintId);
        ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "PersonName", personPaints.PersonId);
        return View(personPaints);
    }

    // POST: PersonPaints/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("Quantity,AcquisitionDate,PersonId,PaintId,AppUserId,Id")] PersonPaints personPaints)
    {
        if (id != personPaints.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(personPaints);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonPaintsExists(personPaints.Id))
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
        ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", personPaints.UserId);
        ViewData["PaintId"] = new SelectList(_context.Paints, "Id", "HexCode", personPaints.PaintId);
        ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "PersonName", personPaints.PersonId);
        return View(personPaints);
    }

    // GET: PersonPaints/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var personPaints = await _context.PersonPaints
            .Include(p => p.User)
            .Include(p => p.Paint)
            .Include(p => p.Person)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (personPaints == null)
        {
            return NotFound();
        }

        return View(personPaints);
    }

    // POST: PersonPaints/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var personPaints = await _context.PersonPaints.FindAsync(id);
        if (personPaints != null)
        {
            _context.PersonPaints.Remove(personPaints);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PersonPaintsExists(Guid id)
    {
        return _context.PersonPaints.Any(e => e.Id == id);
    }
}