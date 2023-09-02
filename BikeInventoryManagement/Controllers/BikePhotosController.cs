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
    public class BikePhotosController : Controller
    {
        private readonly BikeInventoryManagementContext _context;

        public BikePhotosController(BikeInventoryManagementContext context)
        {
            _context = context;
        }

        // GET: BikePhotos
        public async Task<IActionResult> Index()
        {
              return _context.BikePhoto != null ? 
                          View(await _context.BikePhoto.ToListAsync()) :
                          Problem("Entity set 'BikeInventoryManagementContext.BikePhoto'  is null.");
        }

        // GET: BikePhotos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BikePhoto == null)
            {
                return NotFound();
            }

            var bikePhoto = await _context.BikePhoto
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bikePhoto == null)
            {
                return NotFound();
            }

            return View(bikePhoto);
        }

        // GET: BikePhotos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BikePhotos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,FileName,CreatedOn,LastUpdatedOn")] BikePhoto bikePhoto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bikePhoto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bikePhoto);
        }

        // GET: BikePhotos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BikePhoto == null)
            {
                return NotFound();
            }

            var bikePhoto = await _context.BikePhoto.FindAsync(id);
            if (bikePhoto == null)
            {
                return NotFound();
            }
            return View(bikePhoto);
        }

        // POST: BikePhotos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,FileName,CreatedOn,LastUpdatedOn")] BikePhoto bikePhoto)
        {
            if (id != bikePhoto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bikePhoto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BikePhotoExists(bikePhoto.ID))
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
            return View(bikePhoto);
        }

        // GET: BikePhotos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BikePhoto == null)
            {
                return NotFound();
            }

            var bikePhoto = await _context.BikePhoto
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bikePhoto == null)
            {
                return NotFound();
            }

            return View(bikePhoto);
        }

        // POST: BikePhotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BikePhoto == null)
            {
                return Problem("Entity set 'BikeInventoryManagementContext.BikePhoto'  is null.");
            }
            var bikePhoto = await _context.BikePhoto.FindAsync(id);
            if (bikePhoto != null)
            {
                _context.BikePhoto.Remove(bikePhoto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BikePhotoExists(int id)
        {
          return (_context.BikePhoto?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
