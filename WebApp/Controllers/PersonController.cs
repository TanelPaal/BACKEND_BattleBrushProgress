using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
using App.Domain;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers;

[Authorize]
public class PersonController : Controller
{
    private readonly AppDbContext _context;

    public PersonController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Person
    public async Task<IActionResult> Index()
    {
        // TODO - ask only data for current user
        var userIdStr = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
        var userId = Guid.Parse(userIdStr);
        
        var res = await _context
                .Persons
                .Include(p => p.User)
                .Where(p => p.UserId == userId)
                .ToListAsync();
        return View(res);
    }

    // GET: Person/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var person = await _context.Persons
            .Include(p => p.User)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (person == null)
        {
            return NotFound();
        }

        return View(person);
    }

    // GET: Person/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Person/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Person person)
    {
        var userIdStr = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
        var userId = Guid.Parse(userIdStr);
        person.UserId = userId;
        
        if (ModelState.IsValid)
        {
            person.Id = Guid.NewGuid();
            _context.Add(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(person);
    }

    // GET: Person/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var person = await _context.Persons.FindAsync(id);
        if (person == null)
        {
            return NotFound();
        }
        
        // Verify the current user owns this person record
        var userIdStr = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
        var userId = Guid.Parse(userIdStr);
        if (person.UserId != userId)
        {
            return Forbid();
        }
        
        return View(person);
    }

    // POST: Person/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("PersonName,Id")] Person person)
    {
        if (id != person.Id)
        {
            return NotFound();
        }
        
        // Get the original person to preserve the AppUserId
        var originalPerson = await _context.Persons.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        if (originalPerson == null)
        {
            return NotFound();
        }
        
        // Verify the current user owns this person record
        var userIdStr = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
        var userId = Guid.Parse(userIdStr);
        if (originalPerson.UserId != userId)
        {
            return Forbid();
        }
        
        // Set the AppUserId to the original value
        person.UserId = originalPerson.UserId;

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(person);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(person.Id))
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
        // ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", person.AppUserId);
        return View(person);
    }

    // GET: Person/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var person = await _context.Persons
            .Include(p => p.User)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (person == null)
        {
            return NotFound();
        }

        return View(person);
    }

    // POST: Person/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var person = await _context.Persons.FindAsync(id);
        if (person != null)
        {
            _context.Persons.Remove(person);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PersonExists(Guid id)
    {
        return _context.Persons.Any(e => e.Id == id);
    }
}