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
public class PaintLineController : Controller
{
    private readonly IAppUOW _uow;

    public PaintLineController(IAppUOW uow)
    {
        _uow = uow;
    }

    // GET: PaintLine
    public async Task<IActionResult> Index()
    {
        var paintLines = await _uow.PaintLineRepository.AllWithIncludesAsync();
        return View(paintLines);
    }

    // GET: PaintLine/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var paintLine = await _uow.PaintLineRepository.FindWithIncludesAsync(id.Value);
        if (paintLine == null)
        {
            return NotFound();
        }

        return View(paintLine);
    }

    // GET: PaintLine/Create
    public async Task<IActionResult> Create()
    {
        var brands = await _uow.BrandRepository.AllAsync();
        ViewData["BrandId"] = new SelectList(brands, "Id", "BrandName");
        return View();
    }

    // POST: PaintLine/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PaintLine paintLine)
    {
        if (ModelState.IsValid)
        {
            _uow.PaintLineRepository.Add(paintLine);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        var brands = await _uow.BrandRepository.AllAsync();
        ViewData["BrandId"] = new SelectList(brands, "Id", "BrandName", paintLine.BrandId);
        return View(paintLine);
    }

    // GET: PaintLine/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var paintLine = await _uow.PaintLineRepository.FindAsync(id.Value);
        if (paintLine == null)
        {
            return NotFound();
        }

        var brands = await _uow.BrandRepository.AllAsync();
        ViewData["BrandId"] = new SelectList(brands, "Id", "BrandName", paintLine.BrandId);
        return View(paintLine);
    }

    // POST: PaintLine/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, PaintLine paintLine)
    {
        if (id != paintLine.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _uow.PaintLineRepository.Update(paintLine);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        var brands = await _uow.BrandRepository.AllAsync();
        ViewData["BrandId"] = new SelectList(brands, "Id", "BrandName", paintLine.BrandId);
        return View(paintLine);
    }

    // GET: PaintLine/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var paintLine = await _uow.PaintLineRepository.FindWithIncludesAsync(id.Value);
        if (paintLine == null)
        {
            return NotFound();
        }

        return View(paintLine);
    }

    // POST: PaintLine/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await _uow.PaintLineRepository.RemoveAsync(id);
        await _uow.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}