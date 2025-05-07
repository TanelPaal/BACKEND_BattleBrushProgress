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
    public class MiniStatesController : Controller
    {
        private readonly AppDbContext _context;

        public MiniStatesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MiniStates
        public async Task<IActionResult> Index()
        {
            return View(await _context.MiniStates.ToListAsync());
        }

        // GET: MiniStates/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miniState = await _context.MiniStates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miniState == null)
            {
                return NotFound();
            }

            return View(miniState);
        }

        // GET: MiniStates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MiniStates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StateName,StateDesc,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt,SysNotes")] MiniState miniState)
        {
            if (ModelState.IsValid)
            {
                miniState.Id = Guid.NewGuid();
                _context.Add(miniState);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(miniState);
        }

        // GET: MiniStates/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miniState = await _context.MiniStates.FindAsync(id);
            if (miniState == null)
            {
                return NotFound();
            }
            return View(miniState);
        }

        // POST: MiniStates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("StateName,StateDesc,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt,SysNotes")] MiniState miniState)
        {
            if (id != miniState.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(miniState);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiniStateExists(miniState.Id))
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
            return View(miniState);
        }

        // GET: MiniStates/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miniState = await _context.MiniStates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miniState == null)
            {
                return NotFound();
            }

            return View(miniState);
        }

        // POST: MiniStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var miniState = await _context.MiniStates.FindAsync(id);
            if (miniState != null)
            {
                _context.MiniStates.Remove(miniState);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiniStateExists(Guid id)
        {
            return _context.MiniStates.Any(e => e.Id == id);
        }
    }
}
