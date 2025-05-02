using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.DAL.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
using App.Domain;
using Base.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers;

[Authorize]
public class MiniatureCollectionController : Controller
{
    private readonly IMiniatureCollectionRepository _repository;
    private readonly IMiniatureRepository _miniatureRepository;
    private readonly IMiniStateRepository _miniStateRepository;
    private readonly IPersonRepository _personRepository;

    public MiniatureCollectionController(
        IMiniatureCollectionRepository repository,
        IMiniatureRepository miniatureRepository,
        IMiniStateRepository miniStateRepository,
        IPersonRepository personRepository)
    {
        _repository = repository;
        _miniatureRepository = miniatureRepository;
        _miniStateRepository = miniStateRepository;
        _personRepository = personRepository;
    }

    // GET: MiniatureCollection
    public async Task<IActionResult> Index()
    {
        var userId = User.GetUserId();
        var collections = await _repository.AllWithIncludesAsync(userId);
        return View(collections);
    }

    // GET: MiniatureCollection/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var userId = User.GetUserId();
        var miniatureCollection = await _repository.FindWithIncludesAsync(id.Value, userId);
        
        if (miniatureCollection == null)
        {
            return NotFound();
        }

        return View(miniatureCollection);
    }

    // GET: MiniatureCollection/Create
    public async Task<IActionResult> Create()
    {
        await PopulateDropDowns();
        return View();
    }

    // POST: MiniatureCollection/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MiniatureCollection miniatureCollection)
    {
        miniatureCollection.UserId = User.GetUserId();
        
        if (ModelState.IsValid)
        {
            _repository.Add(miniatureCollection);
            await _repository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        await PopulateDropDowns(miniatureCollection);
        return View(miniatureCollection);
    }

    // GET: MiniatureCollection/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var userId = User.GetUserId();
        var miniatureCollection = await _repository.FindAsync(id.Value);
        
        if (miniatureCollection == null || miniatureCollection.UserId != userId)
        {
            return NotFound();
        }
        
        await PopulateDropDowns(miniatureCollection);
        return View(miniatureCollection);
    }

    // POST: MiniatureCollection/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, MiniatureCollection miniatureCollection)
    {
        if (id != miniatureCollection.Id)
        {
            return NotFound();
        }
        
        var userId = User.GetUserId();
        if (!await _repository.IsOwnedByUserAsync(id, userId))
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            miniatureCollection.UserId = userId;
            _repository.Update(miniatureCollection);
            await _repository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        await PopulateDropDowns(miniatureCollection);
        return View(miniatureCollection);
    }

    // GET: MiniatureCollection/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var userId = User.GetUserId();
        var miniatureCollection = await _repository.FindWithIncludesAsync(id.Value, userId);
        
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
        var userId = User.GetUserId();
        if (!await _repository.IsOwnedByUserAsync(id, userId))
        {
            return NotFound();
        }

        await _repository.RemoveAsync(id);
        await _repository.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    
    // Helper method to populate dropdowns
    private async Task PopulateDropDowns(MiniatureCollection? miniatureCollection = null)
    {
        var userId = User.GetUserId();
        
        var miniatures = await _miniatureRepository.AllAsync();
        var miniStates = await _miniStateRepository.AllAsync();
        var persons = await _personRepository.AllAsync(userId);

        ViewData["MiniatureId"] = new SelectList(
            miniatures, 
            "Id", 
            "MiniDesc", 
            miniatureCollection?.MiniatureId);
            
        ViewData["MiniStateId"] = new SelectList(
            miniStates, 
            "Id", 
            "StateName", 
            miniatureCollection?.MiniStateId);
            
        ViewData["PersonId"] = new SelectList(
            persons, 
            "Id", 
            "PersonName", 
            miniatureCollection?.PersonId);
    }
}