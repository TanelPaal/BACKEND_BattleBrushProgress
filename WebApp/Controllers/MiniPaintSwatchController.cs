using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.DAL.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
using App.DAL.DTO;
using Base.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers;

[Authorize]
public class MiniPaintSwatchController : Controller
{
    private readonly IAppUOW _uow;


    public MiniPaintSwatchController(IAppUOW uow)
    {
        _uow = uow;
    }

    // GET: MiniPaintSwatch
    public async Task<IActionResult> Index()
    {
        var res = await _uow.MiniPaintSwatchRepository.AllAsync(User.GetUserId());
        return View(res);
    }

    // GET: MiniPaintSwatch/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var miniPaintSwatch = await _uow.MiniPaintSwatchRepository.FindAsync(id.Value, User.GetUserId());
        if (miniPaintSwatch == null)
        {
            return NotFound();
        }

        return View(miniPaintSwatch);
    }

    // GET: MiniPaintSwatch/Create
    public async Task<IActionResult> Create()
    {
        await PopulateDropDowns();
        return View();
    }

    // POST: MiniPaintSwatch/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MiniPaintSwatch entity)
    {
        /*entity.UserId = User.GetUserId();*/
        
        if (ModelState.IsValid)
        {
            _uow.MiniPaintSwatchRepository.Add(entity, User.GetUserId());
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        await PopulateDropDowns();
        return View(entity);
    }

    // GET: MiniPaintSwatch/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var entity = await _uow.MiniPaintSwatchRepository.FindAsync(id.Value, User.GetUserId());
        if (entity == null)
        {
            return NotFound();
        }

        await PopulateDropDowns();
        return View(entity);
    }

    // POST: MiniPaintSwatch/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, MiniPaintSwatch entity)
    {
        if (id != entity.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _uow.MiniPaintSwatchRepository.Update(entity);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        await PopulateDropDowns();
        return View(entity);
    }

    // GET: MiniPaintSwatch/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var entity = await _uow.MiniPaintSwatchRepository.FindAsync(id.Value, User.GetUserId());
        if (entity == null)
        {
            return NotFound();
        }

        return View(entity);
    }

    // POST: MiniPaintSwatch/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await _uow.MiniPaintSwatchRepository.RemoveAsync(id, User.GetUserId());
        await _uow.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    
    private async Task PopulateDropDowns()
    {
        var userId = User.GetUserId();
        
        ViewData["MiniatureCollectionId"] = new SelectList(
            await _uow.MiniatureCollectionRepository.AllAsync(userId),
            "Id",
            "CollectionName");
            
        ViewData["PersonPaintsId"] = new SelectList(
            await _uow.PersonPaintsRepository.AllAsync(userId),
            "Id",
            "Paint.Name"); // Assuming you want to show the paint name
    }
}