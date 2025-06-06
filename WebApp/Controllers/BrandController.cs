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
public class BrandController : Controller
{
    private readonly IAppBLL _bll;
    
    public BrandController(IAppBLL bll)
    {
        _bll = bll;
    }

    // GET: Brand
    public async Task<IActionResult> Index()
    {
        var res = await _bll.BrandService.AllAsync();
        return View(res);
    }

    // GET: Brand/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var brand = await _bll.BrandService.FindAsync(id.Value);

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
            _bll.BrandService.Add(brand);
            await _bll.SaveChangesAsync();
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

        var brand = await _bll.BrandService.FindAsync(id.Value);
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
            _bll.BrandService.Update(brand);
            await _bll.SaveChangesAsync();
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

        var brand = await _bll.BrandService.FindAsync(id.Value);
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
        await _bll.BrandService.RemoveAsync(id);
        await _bll.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}