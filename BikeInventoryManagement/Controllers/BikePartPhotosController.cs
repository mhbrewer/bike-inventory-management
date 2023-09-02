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
    public class BikePartPhotosController : Controller
    {
        private readonly BikeInventoryManagementContext _context;

        public BikePartPhotosController(BikeInventoryManagementContext context)
        {
            _context = context;
        }

        // GET: BikePartPhotoes
        public async Task<IActionResult> Index()
        {
              return _context.BikePartPhoto != null ? 
                          View(await _context.BikePartPhoto.ToListAsync()) :
                          Problem("Entity set 'BikeInventoryManagementContext.BikePartPhoto'  is null.");
        }

        // GET: BikePartPhotoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BikePartPhoto == null)
            {
                return NotFound();
            }

            var bikePartPhoto = await _context.BikePartPhoto
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bikePartPhoto == null)
            {
                return NotFound();
            }

            return View(bikePartPhoto);
        }

        // GET: BikePartPhotoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BikePartPhotoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,FileName,CreatedOn,LastUpdatedOn")] BikePartPhoto bikePartPhoto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bikePartPhoto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bikePartPhoto);
        }

        // GET: BikePartPhotoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BikePartPhoto == null)
            {
                return NotFound();
            }

            var bikePartPhoto = await _context.BikePartPhoto.FindAsync(id);
            if (bikePartPhoto == null)
            {
                return NotFound();
            }
            return View(bikePartPhoto);
        }

        // POST: BikePartPhotoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,FileName,CreatedOn,LastUpdatedOn")] BikePartPhoto bikePartPhoto)
        {
            if (id != bikePartPhoto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bikePartPhoto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BikePartPhotoExists(bikePartPhoto.ID))
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
            return View(bikePartPhoto);
        }

        // GET: BikePartPhotoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BikePartPhoto == null)
            {
                return NotFound();
            }

            var bikePartPhoto = await _context.BikePartPhoto
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bikePartPhoto == null)
            {
                return NotFound();
            }

            return View(bikePartPhoto);
        }

        // POST: BikePartPhotoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BikePartPhoto == null)
            {
                return Problem("Entity set 'BikeInventoryManagementContext.BikePartPhoto'  is null.");
            }
            var bikePartPhoto = await _context.BikePartPhoto.FindAsync(id);
            if (bikePartPhoto != null)
            {
                _context.BikePartPhoto.Remove(bikePartPhoto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BikePartPhotoExists(int id)
        {
          return (_context.BikePartPhoto?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
