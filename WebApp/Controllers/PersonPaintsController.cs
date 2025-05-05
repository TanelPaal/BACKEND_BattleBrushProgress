using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.DAL.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
using App.DAL.DTO;
using Base.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers;

[Authorize]
public class PersonPaintsController : Controller
{
    private readonly IAppUOW _uow;

    public PersonPaintsController(IAppUOW uow)
    {
        _uow = uow;
    }

    // GET: PersonPaints
    public async Task<IActionResult> Index()
    {
        var res = await _uow.PersonPaintsRepository.AllAsync(User.GetUserId());
        return View(res);
    }

    // GET: PersonPaints/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var personPaints = await _uow.PersonPaintsRepository.FindAsync(id.Value, User.GetUserId());
        if (personPaints == null)
        {
            return NotFound();
        }

        return View(personPaints);
    }

    // GET: PersonPaints/Create
    public async Task<IActionResult> Create()
    {
        await PopulateDropDowns();
        return View();
    }

    // POST: PersonPaints/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PersonPaints entity)
    {
        /*entity.UserId = User.GetUserId();*/
        
        if (ModelState.IsValid)
        {
            _uow.PersonPaintsRepository.Add(entity, User.GetUserId());
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        await PopulateDropDowns();
        return View(entity);
    }

    // GET: PersonPaints/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var entity = await _uow.PersonPaintsRepository.FindAsync(id.Value, User.GetUserId());
        if (entity == null)
        {
            return NotFound();
        }
        
        await PopulateDropDowns();
        return View(entity);
    }

    // POST: PersonPaints/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, PersonPaints entity)
    {
        if (id != entity.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _uow.PersonPaintsRepository.Update(entity);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        await PopulateDropDowns();
        return View(entity);
    }

    // GET: PersonPaints/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var entity = await _uow.PersonPaintsRepository.FindAsync(id.Value, User.GetUserId());
        if (entity == null)
        {
            return NotFound();
        }

        return View(entity);
    }

    // POST: PersonPaints/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await _uow.PersonPaintsRepository.RemoveAsync(id, User.GetUserId());
        await _uow.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    
    // Helper method to populate dropdowns
    private async Task PopulateDropDowns()
    {
        var userId = User.GetUserId();
        
        ViewData["PaintId"] = new SelectList(
            await _uow.PaintRepository.AllAsync(),
            "Id",
            "Name");
            
        ViewData["PersonId"] = new SelectList(
            await _uow.PersonRepository.AllAsync(userId),
            "Id",
            "PersonName");
    }
}