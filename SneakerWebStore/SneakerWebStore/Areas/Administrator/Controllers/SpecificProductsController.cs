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
    public class SpecificProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpecificProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administrator/SpecificProducts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SpecificProducts.Include(s => s.GenericProduct);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Administrator/SpecificProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specificProduct = await _context.SpecificProducts
                .Include(s => s.GenericProduct)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specificProduct == null)
            {
                return NotFound();
            }

            return View(specificProduct);
        }

        // GET: Administrator/SpecificProducts/Create
        public IActionResult Create()
        {
            ViewData["GenericProductId"] = new SelectList(_context.GenericProducts, "Id", "Name");
            return View();
        }

        // POST: Administrator/SpecificProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GenericProductId,Name,Price,OrderType,Stock,IsBuyable,IsPreorderable,ImagePath")] SpecificProduct specificProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specificProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenericProductId"] = new SelectList(_context.GenericProducts, "Id", "Name", specificProduct.GenericProductId);
            return View(specificProduct);
        }

        // GET: Administrator/SpecificProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specificProduct = await _context.SpecificProducts.FindAsync(id);
            if (specificProduct == null)
            {
                return NotFound();
            }
            ViewData["GenericProductId"] = new SelectList(_context.GenericProducts, "Id", "Name", specificProduct.GenericProductId);
            return View(specificProduct);
        }

        // POST: Administrator/SpecificProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GenericProductId,Name,Price,OrderType,Stock,IsBuyable,IsPreorderable,ImagePath")] SpecificProduct specificProduct)
        {
            if (id != specificProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specificProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecificProductExists(specificProduct.Id))
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
            ViewData["GenericProductId"] = new SelectList(_context.GenericProducts, "Id", "Name", specificProduct.GenericProductId);
            return View(specificProduct);
        }

        // GET: Administrator/SpecificProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specificProduct = await _context.SpecificProducts
                .Include(s => s.GenericProduct)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specificProduct == null)
            {
                return NotFound();
            }

            return View(specificProduct);
        }

        // POST: Administrator/SpecificProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specificProduct = await _context.SpecificProducts.FindAsync(id);
            _context.SpecificProducts.Remove(specificProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecificProductExists(int id)
        {
            return _context.SpecificProducts.Any(e => e.Id == id);
        }
    }
}
