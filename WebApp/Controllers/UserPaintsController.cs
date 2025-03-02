using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
using App.Domain;

namespace WebApp.Controllers
{
    public class UserPaintsController : Controller
    {
        private readonly AppDbContext _context;

        public UserPaintsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UserPaints
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.UserPaints.Include(u => u.Paint);
            return View(await appDbContext.ToListAsync());
        }

        // GET: UserPaints/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPaints = await _context.UserPaints
                .Include(u => u.Paint)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userPaints == null)
            {
                return NotFound();
            }

            return View(userPaints);
        }

        // GET: UserPaints/Create
        public IActionResult Create()
        {
            ViewData["PaintId"] = new SelectList(_context.Paints, "Id", "Name");
            return View();
        }

        // POST: UserPaints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Quantity,AcquisitionDate,UserId,PaintId,Id")] UserPaints userPaints)
        {
            if (ModelState.IsValid)
            {
                userPaints.Id = Guid.NewGuid();
                _context.Add(userPaints);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaintId"] = new SelectList(_context.Paints, "Id", "Name", userPaints.PaintId);
            return View(userPaints);
        }

        // GET: UserPaints/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPaints = await _context.UserPaints.FindAsync(id);
            if (userPaints == null)
            {
                return NotFound();
            }
            ViewData["PaintId"] = new SelectList(_context.Paints, "Id", "Name", userPaints.PaintId);
            return View(userPaints);
        }

        // POST: UserPaints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Quantity,AcquisitionDate,UserId,PaintId,Id")] UserPaints userPaints)
        {
            if (id != userPaints.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userPaints);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserPaintsExists(userPaints.Id))
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
            ViewData["PaintId"] = new SelectList(_context.Paints, "Id", "Name", userPaints.PaintId);
            return View(userPaints);
        }

        // GET: UserPaints/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPaints = await _context.UserPaints
                .Include(u => u.Paint)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userPaints == null)
            {
                return NotFound();
            }

            return View(userPaints);
        }

        // POST: UserPaints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var userPaints = await _context.UserPaints.FindAsync(id);
            if (userPaints != null)
            {
                _context.UserPaints.Remove(userPaints);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserPaintsExists(Guid id)
        {
            return _context.UserPaints.Any(e => e.Id == id);
        }
    }
}
