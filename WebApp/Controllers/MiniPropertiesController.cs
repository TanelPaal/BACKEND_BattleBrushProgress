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
public class MiniPropertiesController : Controller
{
    private readonly IMiniPropertiesRepository _repository;

    public MiniPropertiesController(IMiniPropertiesRepository repository)
    {
        _repository = repository;
    }

    // GET: MiniProperties
    public async Task<IActionResult> Index()
    {
        var properties = await _repository.AllAsync();
        return View(properties);
    }

    // GET: MiniProperties/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var miniProperties = await _repository.FindAsync(id.Value);
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
    public async Task<IActionResult> Create(MiniProperties miniProperties)
    {
        if (ModelState.IsValid)
        {
            _repository.Add(miniProperties);
            await _repository.SaveChangesAsync();
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

        var miniProperties = await _repository.FindAsync(id.Value);
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
    public async Task<IActionResult> Edit(Guid id, MiniProperties miniProperties)
    {
        if (id != miniProperties.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _repository.Update(miniProperties);
            await _repository.SaveChangesAsync();
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

        var miniProperties = await _repository.FindAsync(id.Value);
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
        await _repository.RemoveAsync(id);
        await _repository.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}