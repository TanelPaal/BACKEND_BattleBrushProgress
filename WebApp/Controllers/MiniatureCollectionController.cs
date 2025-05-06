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
using Base.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers;

[Authorize]
public class MiniatureCollectionController : Controller
{
    private readonly IAppBLL _bll;

    public MiniatureCollectionController(IAppBLL bll)
    {
        _bll = bll;
    }

    // GET: MiniatureCollection
    public async Task<IActionResult> Index()
    {
        var res = await _bll.MiniatureCollectionService.AllAsync(User.GetUserId());
        return View(res);
    }

    // GET: MiniatureCollection/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var miniatureCollection = await _bll.MiniatureCollectionService.FindAsync(id.Value, User.GetUserId());
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
    public async Task<IActionResult> Create(MiniatureCollection entity)
    {
        /*entity.UserId = User.GetUserId();*/
        
        if (ModelState.IsValid)
        {
            _bll.MiniatureCollectionService.Add(entity, User.GetUserId());
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        await PopulateDropDowns();
        return View(entity);
    }

    // GET: MiniatureCollection/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var entity = await _bll.MiniatureCollectionService.FindAsync(id.Value, User.GetUserId());
        if (entity == null)
        {
            return NotFound();
        }

        await PopulateDropDowns();
        return View(entity);
    }

    // POST: MiniatureCollection/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, MiniatureCollection entity)
    {
        if (id != entity.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _bll.MiniatureCollectionService.Update(entity);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        await PopulateDropDowns();
        return View(entity);
    }

    // GET: MiniatureCollection/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var entity = await _bll.MiniatureCollectionService.FindAsync(id.Value, User.GetUserId());
        if (entity == null)
        {
            return NotFound();
        }

        return View(entity);
    }

    // POST: MiniatureCollection/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await _bll.MiniatureCollectionService.RemoveAsync(id, User.GetUserId());
        await _bll.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    
    // Helper method to populate dropdowns
    private async Task PopulateDropDowns()
    {
        var userId = User.GetUserId();
        
        ViewData["MiniatureId"] = new SelectList(
            await _bll.MiniatureService.AllAsync(),
            "Id",
            "MiniDesc");
            
        ViewData["MiniStateId"] = new SelectList(
            await _bll.MiniStateService.AllAsync(),
            "Id",
            "StateName");
            
        ViewData["PersonId"] = new SelectList(
            await _bll.PersonService.AllAsync(userId),
            "Id",
            "PersonName");
    }
}