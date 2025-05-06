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
public class PaintController : Controller
{
    private readonly IAppBLL _bll;

    public PaintController(IAppBLL bll)
    {
        _bll = bll;
    }

    // GET: Paint
    public async Task<IActionResult> Index()
    {
        var paints = await _bll.PaintService.AllAsync();
        return View(paints);
    }

    // GET: Paint/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var paint = await _bll.PaintService.FindAsync(id.Value);
        if (paint == null)
        {
            return NotFound();
        }

        return View(paint);
    }

    // GET: Paint/Create
    public async Task<IActionResult> Create()
    {
        await PopulateDropDowns();
        return View();
    }

    // POST: Paint/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Paint paint)
    {
        if (ModelState.IsValid)
        {
            _bll.PaintService.Add(paint);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        await PopulateDropDowns(paint);
        return View(paint);
    }

    // GET: Paint/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var paint = await _bll.PaintService.FindAsync(id.Value);
        if (paint == null)
        {
            return NotFound();
        }
        
        await PopulateDropDowns(paint);
        return View(paint);
    }

    // POST: Paint/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, Paint paint)
    {
        if (id != paint.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _bll.PaintService.Update(paint);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        await PopulateDropDowns(paint);
        return View(paint);
    }

    // GET: Paint/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var paint = await _bll.PaintService.FindAsync(id.Value);
        if (paint == null)
        {
            return NotFound();
        }

        return View(paint);
    }

    // POST: Paint/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await _bll.PaintService.RemoveAsync(id);
        await _bll.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    
    // Helper method to populate dropdowns
    private async Task PopulateDropDowns(Paint? paint = null)
    {
        var brands = await _bll.BrandService.AllAsync();
        var paintLines = await _bll.PaintLineService.AllAsync();
        var paintTypes = await _bll.PaintTypeService.AllAsync();

        ViewData["BrandId"] = new SelectList(brands, "Id", "BrandName", paint?.BrandId);
        ViewData["PaintLineId"] = new SelectList(paintLines, "Id", "PaintLineName", paint?.PaintLineId);
        ViewData["PaintTypeId"] = new SelectList(paintTypes, "Id", "Name", paint?.PaintTypeId);
    }
}