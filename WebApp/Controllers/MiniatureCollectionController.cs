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
public class MiniatureCollectionController : Controller
{
    private readonly AppDbContext _context;

    public MiniatureCollectionController(AppDbContext context)
    {
        _context = context;
    }

    // GET: MiniatureCollection
    public async Task<IActionResult> Index()
    {
        var appDbContext = _context.MiniatureCollections.Include(m => m.User).Include(m => m.Miniature).Include(m => m.MiniState).Include(m => m.Person);
        return View(await appDbContext.ToListAsync());
    }

    // GET: MiniatureCollection/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var miniatureCollection = await _context.MiniatureCollections
            .Include(m => m.User)
            .Include(m => m.Miniature)
            .Include(m => m.MiniState)
            .Include(m => m.Person)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (miniatureCollection == null)
        {
            return NotFound();
        }

        return View(miniatureCollection);
    }

    // GET: MiniatureCollection/Create
    public IActionResult Create()
    {
        ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id");
        ViewData["MiniatureId"] = new SelectList(_context.Miniatures, "Id", "MiniDesc");
        ViewData["MiniStateId"] = new SelectList(_context.MiniStates, "Id", "StateDesc");
        ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "PersonName");
        return View();
    }

    // POST: MiniatureCollection/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CollectionName,CollectionDesc,AcquisitionDate,CompletionDate,MiniatureId,MiniStateId,PersonId,AppUserId,Id")] MiniatureCollection miniatureCollection)
    {
        if (ModelState.IsValid)
        {
            miniatureCollection.Id = Guid.NewGuid();
            _context.Add(miniatureCollection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", miniatureCollection.UserId);
        ViewData["MiniatureId"] = new SelectList(_context.Miniatures, "Id", "MiniDesc", miniatureCollection.MiniatureId);
        ViewData["MiniStateId"] = new SelectList(_context.MiniStates, "Id", "StateDesc", miniatureCollection.MiniStateId);
        ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "PersonName", miniatureCollection.PersonId);
        return View(miniatureCollection);
    }

    // GET: MiniatureCollection/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var miniatureCollection = await _context.MiniatureCollections.FindAsync(id);
        if (miniatureCollection == null)
        {
            return NotFound();
        }
        ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", miniatureCollection.UserId);
        ViewData["MiniatureId"] = new SelectList(_context.Miniatures, "Id", "MiniDesc", miniatureCollection.MiniatureId);
        ViewData["MiniStateId"] = new SelectList(_context.MiniStates, "Id", "StateDesc", miniatureCollection.MiniStateId);
        ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "PersonName", miniatureCollection.PersonId);
        return View(miniatureCollection);
    }

    // POST: MiniatureCollection/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("CollectionName,CollectionDesc,AcquisitionDate,CompletionDate,MiniatureId,MiniStateId,PersonId,AppUserId,Id")] MiniatureCollection miniatureCollection)
    {
        if (id != miniatureCollection.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(miniatureCollection);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MiniatureCollectionExists(miniatureCollection.Id))
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
        ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", miniatureCollection.UserId);
        ViewData["MiniatureId"] = new SelectList(_context.Miniatures, "Id", "MiniDesc", miniatureCollection.MiniatureId);
        ViewData["MiniStateId"] = new SelectList(_context.MiniStates, "Id", "StateDesc", miniatureCollection.MiniStateId);
        ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "PersonName", miniatureCollection.PersonId);
        return View(miniatureCollection);
    }

    // GET: MiniatureCollection/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var miniatureCollection = await _context.MiniatureCollections
            .Include(m => m.User)
            .Include(m => m.Miniature)
            .Include(m => m.MiniState)
            .Include(m => m.Person)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (miniatureCollection == null)
        {
            return NotFound();
        }

        return View(miniatureCollection);
    }

    // POST: MiniatureCollection/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var miniatureCollection = await _context.MiniatureCollections.FindAsync(id);
        if (miniatureCollection != null)
        {
            _context.MiniatureCollections.Remove(miniatureCollection);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MiniatureCollectionExists(Guid id)
    {
        return _context.MiniatureCollections.Any(e => e.Id == id);
    }
}