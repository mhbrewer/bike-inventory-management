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
    public class BikesController : Controller
    {
        private readonly BikeInventoryManagementContext _context;

        public BikesController(BikeInventoryManagementContext context)
        {
            _context = context;
        }

        // GET: Bikes
        public async Task<IActionResult> Index()
        {
              return _context.Bike != null ? 
                          View(await _context.Bike.Include(b => b.BikeType).Include(b => b.StorageLocation).ToListAsync()) :
                          Problem("Entity set 'BikeInventoryManagementContext.Bike'  is null.");
        }

        // GET: Bikes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bike == null)
            {
                return NotFound();
            }

            var bike = await _context.Bike.Include(b => b.BikeType).Include(b => b.StorageLocation)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bike == null)
            {
                return NotFound();
            }

            return View(bike);
        }

        // GET: Bikes/Create
        public async Task<IActionResult> Create()
        {
            if(_context.BikeType == null || _context.Location == null)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.BikeTypes = await _context.BikeType.ToListAsync();
            ViewBag.Locations = await _context.Location.ToListAsync();

            return View();
        }

        // POST: Bikes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("ID,Brand,Model,Color,FrameSizeCm,IsBoxed,SerialNumber,Condition,IsListable,Cost,ListPrice,InventoryCount,Notes," +
                "CreatedOn,LastUpdatedOn")] Bike bike, 
            int selectedBikeTypeId, 
            int selectedLocationId)
        {
            bike.BikeType = await _context.BikeType.FindAsync(selectedBikeTypeId);
            bike.StorageLocation = await _context.Location.FindAsync(selectedLocationId);

            if (ModelState.IsValid)
            {
                _context.Add(bike);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction();
        }

        // GET: Bikes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bike == null)
            {
                return NotFound();
            }

            Bike? bike = await _context.Bike.Include(b => b.BikeType).Include(b => b.StorageLocation).FirstOrDefaultAsync(b => b.ID == id);
            if (bike == null)
            {
                return NotFound();
            }

            ViewBag.BikeTypes = await _context.BikeType.ToListAsync();
            ViewBag.Locations = await _context.Location.ToListAsync();

            return View(bike);
        }

        // POST: Bikes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id, 
            [Bind("ID,Brand,Model,Color,FrameSizeCm,IsBoxed,SerialNumber,Condition,IsListable,Cost,ListPrice,InventoryCount,Notes," +
                "CreatedOn,LastUpdatedOn")] Bike bike,
            int selectedBikeTypeId,
            int selectedLocationId)
        {
            if (id != bike.ID)
            {
                return NotFound();
            }

            bike.BikeType = await _context.BikeType.FindAsync(selectedBikeTypeId);
            bike.StorageLocation = await _context.Location.FindAsync(selectedLocationId);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bike);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BikeExists(bike.ID))
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
            return RedirectToAction();
        }

        // GET: Bikes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bike == null)
            {
                return NotFound();
            }

            var bike = await _context.Bike.Include(b => b.BikeType).Include(b => b.StorageLocation)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bike == null)
            {
                return NotFound();
            }

            return View(bike);
        }

        // POST: Bikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bike == null)
            {
                return Problem("Entity set 'BikeInventoryManagementContext.Bike'  is null.");
            }
            var bike = await _context.Bike.FindAsync(id);
            if (bike != null)
            {
                _context.Bike.Remove(bike);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BikeExists(int id)
        {
          return (_context.Bike?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
