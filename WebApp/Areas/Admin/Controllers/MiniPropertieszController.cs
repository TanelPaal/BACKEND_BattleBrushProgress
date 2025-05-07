using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
using App.Domain;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Areas_Admin_Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class MiniPropertieszController : Controller
    {
        private readonly AppDbContext _context;

        public MiniPropertieszController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MiniPropertiesz
        public async Task<IActionResult> Index()
        {
            return View(await _context.MiniProperties.ToListAsync());
        }

        // GET: MiniPropertiesz/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miniProperties = await _context.MiniProperties
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miniProperties == null)
            {
                return NotFound();
            }

            return View(miniProperties);
        }

        // GET: MiniPropertiesz/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MiniPropertiesz/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PropertyName,PropertyDesc,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt,SysNotes")] MiniProperties miniProperties)
        {
            if (ModelState.IsValid)
            {
                miniProperties.Id = Guid.NewGuid();
                _context.Add(miniProperties);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(miniProperties);
        }

        // GET: MiniPropertiesz/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miniProperties = await _context.MiniProperties.FindAsync(id);
            if (miniProperties == null)
            {
                return NotFound();
            }
            return View(miniProperties);
        }

        // POST: MiniPropertiesz/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PropertyName,PropertyDesc,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt,SysNotes")] MiniProperties miniProperties)
        {
            if (id != miniProperties.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(miniProperties);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiniPropertiesExists(miniProperties.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(miniProperties);
        }

        // GET: MiniPropertiesz/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miniProperties = await _context.MiniProperties
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miniProperties == null)
            {
                return NotFound();
            }

            return View(miniProperties);
        }

        // POST: MiniPropertiesz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var miniProperties = await _context.MiniProperties.FindAsync(id);
            if (miniProperties != null)
            {
                _context.MiniProperties.Remove(miniProperties);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiniPropertiesExists(Guid id)
        {
            return _context.MiniProperties.Any(e => e.Id == id);
        }
    }
}
