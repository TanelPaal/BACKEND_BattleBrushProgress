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
public class MiniManufacturerController : Controller
{
    private readonly IMiniManufacturerRepository _repository;

    public MiniManufacturerController(IMiniManufacturerRepository repository)
    {
        _repository = repository;
    }

    // GET: MiniManufacturer
    public async Task<IActionResult> Index()
    {
        var manufacturers = await _repository.AllAsync();
        return View(manufacturers);
    }

    // GET: MiniManufacturer/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var miniManufacturer = await _repository.FindAsync(id.Value);
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
    public async Task<IActionResult> Create(MiniManufacturer miniManufacturer)
    {
        if (ModelState.IsValid)
        {
            _repository.Add(miniManufacturer);
            await _repository.SaveChangesAsync();
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

        var miniManufacturer = await _repository.FindAsync(id.Value);
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
    public async Task<IActionResult> Edit(Guid id, MiniManufacturer miniManufacturer)
    {
        if (id != miniManufacturer.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _repository.Update(miniManufacturer);
            await _repository.SaveChangesAsync();
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

        var miniManufacturer = await _repository.FindAsync(id.Value);
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
        await _repository.RemoveAsync(id);
        await _repository.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}