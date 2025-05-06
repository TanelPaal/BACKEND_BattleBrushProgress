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
public class MiniPaintSwatchController : Controller
{
    private readonly IAppBLL _bll;

    public MiniPaintSwatchController(IAppBLL bll)
    {
        _bll = bll;
    }

    // GET: MiniPaintSwatch
    public async Task<IActionResult> Index()
    {
        var res = await _bll.MiniPaintSwatchService.AllAsync(User.GetUserId());
        return View(res);
    }

    // GET: MiniPaintSwatch/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var miniPaintSwatch = await _bll.MiniPaintSwatchService.FindAsync(id.Value, User.GetUserId());
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
            _bll.MiniPaintSwatchService.Add(entity, User.GetUserId());
            await _bll.SaveChangesAsync();
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

        var entity = await _bll.MiniPaintSwatchService.FindAsync(id.Value, User.GetUserId());
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
            _bll.MiniPaintSwatchService.Update(entity);
            await _bll.SaveChangesAsync();
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

        var entity = await _bll.MiniPaintSwatchService.FindAsync(id.Value, User.GetUserId());
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
        await _bll.MiniPaintSwatchService.RemoveAsync(id, User.GetUserId());
        await _bll.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    
    private async Task PopulateDropDowns()
    {
        var userId = User.GetUserId();
        
        ViewData["MiniatureCollectionId"] = new SelectList(
            await _bll.MiniatureCollectionService.AllAsync(userId),
            "Id",
            "CollectionName");
            
        ViewData["PersonPaintsId"] = new SelectList(
            await _bll.PersonPaintsService.AllAsync(userId),
            "Id",
            "Paint.Name"); // Assuming you want to show the paint name
    }
}