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
public class PaintTypeController : Controller
{
    
    private readonly IAppUOW _uow;

    public PaintTypeController(IAppUOW uow)
    {
        _uow = uow;
    }

    // GET: PaintType
    public async Task<IActionResult> Index()
    {
        var paintTypes = await _uow.PaintTypeRepository.AllAsync();
        return View(paintTypes);
    }

    // GET: PaintType/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var paintType = await _uow.PaintTypeRepository.FindAsync(id.Value);
        if (paintType == null)
        {
            return NotFound();
        }

        return View(paintType);
    }

    // GET: PaintType/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PaintType/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PaintType paintType)
    {
        if (ModelState.IsValid)
        {
            _uow.PaintTypeRepository.Add(paintType);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(paintType);
    }

    // GET: PaintType/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var paintType = await _uow.PaintTypeRepository.FindAsync(id.Value);
        if (paintType == null)
        {
            return NotFound();
        }
        return View(paintType);
    }

    // POST: PaintType/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, PaintType paintType)
    {
        if (id != paintType.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _uow.PaintTypeRepository.Update(paintType); 
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(paintType);
    }

    // GET: PaintType/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var paintType = await _uow.PaintTypeRepository.FindAsync(id.Value);
        if (paintType == null)
        {
            return NotFound();
        }

        return View(paintType);
    }

    // POST: PaintType/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await _uow.PaintTypeRepository.RemoveAsync(id);
        await _uow.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}