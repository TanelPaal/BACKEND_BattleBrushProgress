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
public class BrandController : Controller
{
    //private readonly AppDbContext _context;
    private readonly IBrandRepository _repository;
    
    public BrandController(IBrandRepository repository)
    {
        _repository = repository;
    }

    // GET: Brand
    public async Task<IActionResult> Index()
    {
        var res = await _repository.AllAsync();
        return View(res);
    }

    // GET: Brand/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var brand = await _repository.FindAsync(id.Value);

        if (brand == null)
        {
            return NotFound();
        }

        return View(brand);
    }

    // GET: Brand/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Brand/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Brand brand)
    {
        if (ModelState.IsValid)
        {
            _repository.Add(brand);
            await _repository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(brand);
    }

    // GET: Brand/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var brand = await _repository.FindAsync(id.Value);
        if (brand == null)
        {
            return NotFound();
        }
        return View(brand);
    }

    // POST: Brand/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, Brand brand)
    {
        if (id != brand.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _repository.Update(brand);
            await _repository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(brand);
    }

    // GET: Brand/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var brand = await _repository.FindAsync(id.Value);
        if (brand == null)
        {
            return NotFound();
        }

        return View(brand);
    }

    // POST: Brand/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await _repository.RemoveAsync(id);
        await _repository.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}