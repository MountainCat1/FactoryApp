using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FactoryApp.Models;
using FactoryApp.Services;

namespace FactoryApp.Views.Workshop
{
    public class WorkshopController : Controller
    {
        private readonly FactoryDbContext _context;

        public WorkshopController(FactoryDbContext context)
        {
            _context = context;
        }

        // GET: Workshop
        public async Task<IActionResult> Index()
        {
            var factoryDbContext = _context.Workshops.Include(w => w.DirectorModel);
            return View(await factoryDbContext.ToListAsync());
        }

        // GET: Workshop/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Workshops == null)
            {
                return NotFound();
            }

            var workshopModel = await _context.Workshops
                .Include(w => w.DirectorModel)
                .FirstOrDefaultAsync(m => m.Region == id);
            if (workshopModel == null)
            {
                return NotFound();
            }

            return View(workshopModel);
        }

        // GET: Workshop/Create
        public IActionResult Create()
        {
            ViewData["DirectorId"] = new SelectList(_context.Directors, "Id", "Id");
            return View();
        }

        // POST: Workshop/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Region,DirectorId")] WorkshopModel workshopModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workshopModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DirectorId"] = new SelectList(_context.Directors, "Id", "Id", workshopModel.DirectorId);
            return View(workshopModel);
        }

        // GET: Workshop/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Workshops == null)
            {
                return NotFound();
            }

            var workshopModel = await _context.Workshops.FindAsync(id);
            if (workshopModel == null)
            {
                return NotFound();
            }
            ViewData["DirectorId"] = new SelectList(_context.Directors, "Id", "Id", workshopModel.DirectorId);
            return View(workshopModel);
        }

        // POST: Workshop/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Region,DirectorId")] WorkshopModel workshopModel)
        {
            if (id != workshopModel.Region)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workshopModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkshopModelExists(workshopModel.Region))
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
            ViewData["DirectorId"] = new SelectList(_context.Directors, "Id", "Id", workshopModel.DirectorId);
            return View(workshopModel);
        }

        // GET: Workshop/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Workshops == null)
            {
                return NotFound();
            }

            var workshopModel = await _context.Workshops
                .Include(w => w.DirectorModel)
                .FirstOrDefaultAsync(m => m.Region == id);
            if (workshopModel == null)
            {
                return NotFound();
            }

            return View(workshopModel);
        }

        // POST: Workshop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Workshops == null)
            {
                return Problem("Entity set 'FactoryDbContext.Workshops'  is null.");
            }
            var workshopModel = await _context.Workshops.FindAsync(id);
            if (workshopModel != null)
            {
                _context.Workshops.Remove(workshopModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkshopModelExists(string id)
        {
          return (_context.Workshops?.Any(e => e.Region == id)).GetValueOrDefault();
        }
    }
}
