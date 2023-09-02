using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BikeInventoryManagement.Data;
using BikeInventoryManagement.Models;

namespace BikeInventoryManagement.Controllers
{
    public class BikePartsController : Controller
    {
        private readonly BikeInventoryManagementContext _context;

        public BikePartsController(BikeInventoryManagementContext context)
        {
            _context = context;
        }

        // GET: BikeParts
        public async Task<IActionResult> Index()
        {
              return _context.BikePart != null ? 
                          View(await _context.BikePart.Include(p => p.StorageLocation).ToListAsync()) :
                          Problem("Entity set 'BikeInventoryManagementContext.BikePart'  is null.");
        }

        // GET: BikeParts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BikePart == null)
            {
                return NotFound();
            }

            var bikePart = await _context.BikePart.Include(p => p.StorageLocation)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bikePart == null)
            {
                return NotFound();
            }

            return View(bikePart);
        }

        // GET: BikeParts/Create
        public async Task<IActionResult> Create()
        {
            if (_context.Location == null)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Locations = await _context.Location.ToListAsync();

            return View();
        }

        // POST: BikeParts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("ID,PartName,Brand,Color,IsBoxed,Notes,IsListable,ListPrice,Cost,InventoryCount,CreatedOn,LastUpdatedOn")] BikePart bikePart,
            int selectedLocationId)
        {
            bikePart.StorageLocation = await _context.Location.FindAsync(selectedLocationId);

            if (ModelState.IsValid)
            {
                _context.Add(bikePart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction();
        }

        // GET: BikeParts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BikePart == null)
            {
                return NotFound();
            }

            var bikePart = await _context.BikePart.Include(p => p.StorageLocation).FirstOrDefaultAsync(p => p.ID == id);
            if (bikePart == null)
            {
                return NotFound();
            }

            ViewBag.Locations = await _context.Location.ToListAsync();

            return View(bikePart);
        }

        // POST: BikeParts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id, 
            [Bind("ID,PartName,Brand,Color,IsBoxed,Notes,IsListable,ListPrice,Cost,InventoryCount,CreatedOn,LastUpdatedOn")] BikePart bikePart,
            int selectedLocationId)
        {
            if (id != bikePart.ID)
            {
                return NotFound();
            }

            bikePart.StorageLocation = await _context.Location.FindAsync(selectedLocationId);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bikePart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BikePartExists(bikePart.ID))
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
            return View(bikePart);
        }

        // GET: BikeParts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BikePart == null)
            {
                return NotFound();
            }

            var bikePart = await _context.BikePart.Include(p => p.StorageLocation)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bikePart == null)
            {
                return NotFound();
            }

            return View(bikePart);
        }

        // POST: BikeParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BikePart == null)
            {
                return Problem("Entity set 'BikeInventoryManagementContext.BikePart'  is null.");
            }
            var bikePart = await _context.BikePart.FindAsync(id);
            if (bikePart != null)
            {
                _context.BikePart.Remove(bikePart);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BikePartExists(int id)
        {
          return (_context.BikePart?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
