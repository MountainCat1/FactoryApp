using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FactoryApp.Models;
using FactoryApp.Services;

namespace FactoryApp.Views.Repairmen
{
    public class RepairmenController : Controller
    {
        private readonly FactoryDbContext _context;

        public RepairmenController(FactoryDbContext context)
        {
            _context = context;
        }

        // GET: Repairmen
        public async Task<IActionResult> Index()
        {
              return _context.Repairmen != null ? 
                          View(await _context.Repairmen.ToListAsync()) :
                          Problem("Entity set 'FactoryDbContext.RepairmenModel'  is null.");
        }

        // GET: Repairmen/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Repairmen == null)
            {
                return NotFound();
            }

            var repairmenModel = await _context.Repairmen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repairmenModel == null)
            {
                return NotFound();
            }

            return View(repairmenModel);
        }

        // GET: Repairmen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Repairmen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName")] RepairmenModel repairmenModel)
        {
            if (ModelState.IsValid)
            {
                repairmenModel.Id = Guid.NewGuid();
                _context.Add(repairmenModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(repairmenModel);
        }

        // GET: Repairmen/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Repairmen == null)
            {
                return NotFound();
            }

            var repairmenModel = await _context.Repairmen.FindAsync(id);
            if (repairmenModel == null)
            {
                return NotFound();
            }
            return View(repairmenModel);
        }

        // POST: Repairmen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FullName")] RepairmenModel repairmenModel)
        {
            if (id != repairmenModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repairmenModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepairmenModelExists(repairmenModel.Id))
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
            return View(repairmenModel);
        }

        // GET: Repairmen/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Repairmen == null)
            {
                return NotFound();
            }

            var repairmenModel = await _context.Repairmen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repairmenModel == null)
            {
                return NotFound();
            }

            return View(repairmenModel);
        }

        // POST: Repairmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Repairmen == null)
            {
                return Problem("Entity set 'FactoryDbContext.RepairmenModel'  is null.");
            }
            var repairmenModel = await _context.Repairmen.FindAsync(id);
            if (repairmenModel != null)
            {
                _context.Repairmen.Remove(repairmenModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepairmenModelExists(Guid id)
        {
          return (_context.Repairmen?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
