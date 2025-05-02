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
public class MiniFactionController : Controller
{
    private readonly IAppUOW _uow;

    public MiniFactionController(IAppUOW uow)
    {
        _uow = uow;
    }

    // GET: MiniFaction
    public async Task<IActionResult> Index()
    {
        var factions = await _uow.MiniFactionRepository.AllAsync();
        return View(factions);
    }

    // GET: MiniFaction/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var miniFaction = await _uow.MiniFactionRepository.FindAsync(id.Value);
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
    public async Task<IActionResult> Create(MiniFaction miniFaction)
    {
        if (ModelState.IsValid)
        {
            _uow.MiniFactionRepository.Add(miniFaction);
            await _uow.SaveChangesAsync();
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

        var miniFaction = await _uow.MiniFactionRepository.FindAsync(id.Value);
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
    public async Task<IActionResult> Edit(Guid id, MiniFaction miniFaction)
    {
        if (id != miniFaction.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _uow.MiniFactionRepository.Update(miniFaction);
            await _uow.SaveChangesAsync();
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

        var miniFaction = await _uow.MiniFactionRepository.FindAsync(id.Value);
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
        await _uow.MiniFactionRepository.RemoveAsync(id);
        await _uow.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}