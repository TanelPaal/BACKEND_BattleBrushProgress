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
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers;

[Authorize]
public class MiniStateController : Controller
{
    private readonly IMiniStateRepository _repository;

    public MiniStateController(IMiniStateRepository repository)
    {
        _repository = repository;
    }

    // GET: MiniState
    public async Task<IActionResult> Index()
    {
        var states = await _repository.AllAsync();
        return View(states);
    }

    // GET: MiniState/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var miniState = await _repository.FindAsync(id.Value);
        if (miniState == null)
        {
            return NotFound();
        }

        return View(miniState);
    }

    // GET: MiniState/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: MiniState/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MiniState miniState)
    {
        if (ModelState.IsValid)
        {
            _repository.Add(miniState);
            await _repository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(miniState);
    }

    // GET: MiniState/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var miniState = await _repository.FindAsync(id.Value);
        if (miniState == null)
        {
            return NotFound();
        }
        return View(miniState);
    }

    // POST: MiniState/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, MiniState miniState)
    {
        if (id != miniState.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _repository.Update(miniState);
            await _repository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(miniState);
    }

    // GET: MiniState/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var miniState = await _repository.FindAsync(id.Value);
        if (miniState == null)
        {
            return NotFound();
        }

        return View(miniState);
    }

    // POST: MiniState/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await _repository.RemoveAsync(id);
        await _repository.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}