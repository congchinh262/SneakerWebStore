using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SneakerWebStore.Models;
using SneakerWebStore.Data;

namespace SneakerWebStore.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class GenericProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GenericProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administrator/GenericProducts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GenericProducts.Include(g => g.Manufacturer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Administrator/GenericProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genericProduct = await _context.GenericProducts
                .Include(g => g.Manufacturer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genericProduct == null)
            {
                return NotFound();
            }

            return View(genericProduct);
        }

        // GET: Administrator/GenericProducts/Create
        public IActionResult Create()
        {
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name");
            return View();
        }

        // POST: Administrator/GenericProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ManufacturerId,Name,Details")] GenericProduct genericProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genericProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name", genericProduct.ManufacturerId);
            return View(genericProduct);
        }

        // GET: Administrator/GenericProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genericProduct = await _context.GenericProducts.FindAsync(id);
            if (genericProduct == null)
            {
                return NotFound();
            }
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name", genericProduct.ManufacturerId);
            return View(genericProduct);
        }

        // POST: Administrator/GenericProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ManufacturerId,Name,Details")] GenericProduct genericProduct)
        {
            if (id != genericProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genericProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenericProductExists(genericProduct.Id))
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
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name", genericProduct.ManufacturerId);
            return View(genericProduct);
        }

        // GET: Administrator/GenericProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genericProduct = await _context.GenericProducts
                .Include(g => g.Manufacturer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genericProduct == null)
            {
                return NotFound();
            }

            return View(genericProduct);
        }

        // POST: Administrator/GenericProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genericProduct = await _context.GenericProducts.FindAsync(id);
            _context.GenericProducts.Remove(genericProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenericProductExists(int id)
        {
            return _context.GenericProducts.Any(e => e.Id == id);
        }
    }
}
