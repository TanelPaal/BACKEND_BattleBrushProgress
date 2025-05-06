using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.BLL.Contracts;
using App.DAL.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
using App.BLL.DTO;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers;

[Authorize]
public class MiniatureController : Controller
{
    private readonly IAppBLL _bll;

    public MiniatureController(IAppBLL bll)
    {
        _bll = bll;
    }

    // GET: Miniature
    public async Task<IActionResult> Index()
    {
        var miniatures = await _bll.MiniatureService.AllAsync();
        return View(miniatures);
    }

    // GET: Miniature/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var miniature = await _bll.MiniatureService.FindAsync(id.Value);
        if (miniature == null)
        {
            return NotFound();
        }

        return View(miniature);
    }

    // GET: Miniature/Create
    public async Task<IActionResult> Create()
    {
        await PopulateDropDowns();
        return View();
    }

    // POST: Miniature/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Miniature miniature)
    {
        if (ModelState.IsValid)
        {
            _bll.MiniatureService.Add(miniature);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        await PopulateDropDowns(miniature);
        return View(miniature);
    }

    // GET: Miniature/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var miniature = await _bll.MiniatureService.FindAsync(id.Value);
        if (miniature == null)
        {
            return NotFound();
        }
        await PopulateDropDowns(miniature);
        return View(miniature);
    }

    // POST: Miniature/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, Miniature miniature)
    {
        if (id != miniature.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _bll.MiniatureService.Update(miniature);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        await PopulateDropDowns(miniature);
        return View(miniature);
    }

    // GET: Miniature/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var miniature = await _bll.MiniatureService.FindAsync(id.Value);
        if (miniature == null)
        {
            return NotFound();
        }

        return View(miniature);
    }

    // POST: Miniature/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await _bll.MiniatureService.RemoveAsync(id);
        await _bll.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    
    // Helper method to populate dropdowns
    private async Task PopulateDropDowns(Miniature? miniature = null)
    {
        var factions = await _bll.MiniFactionService.AllAsync();
        var manufacturers = await _bll.MiniManufacturerService.AllAsync();
        var properties = await _bll.MiniPropertiesService.AllAsync();

        ViewData["MiniFactionId"] = new SelectList(
            factions, 
            "Id", 
            "FactionName", 
            miniature?.MiniFactionId);
            
        ViewData["MiniManufacturerId"] = new SelectList(
            manufacturers, 
            "Id", 
            "ManufacturerName", 
            miniature?.MiniManufacturerId);
            
        ViewData["MiniPropertiesId"] = new SelectList(
            properties, 
            "Id", 
            "PropertyName", 
            miniature?.MiniPropertiesId);
    }
}