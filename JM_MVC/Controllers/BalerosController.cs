using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JM_MVC.Models;

namespace JM_MVC.Controllers
{
    public class BalerosController : Controller
    {
        private readonly MvcPruebasContext _context;

        public BalerosController(MvcPruebasContext context)
        {
            _context = context;
        }

        // GET: Baleros
        public async Task<IActionResult> Index()
        {
              return View(await _context.Baleros.ToListAsync());
        }

        // GET: Baleros/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Baleros == null)
            {
                return NotFound();
            }

            var balero = await _context.Baleros
                .FirstOrDefaultAsync(m => m.IdBaleros == id);
            if (balero == null)
            {
                return NotFound();
            }

            return View(balero);
        }

        // GET: Baleros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Baleros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBaleros,Marca,Codigo,Precio,FechaCreate")] Balero balero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(balero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(balero);
        }

        // GET: Baleros/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Baleros == null)
            {
                return NotFound();
            }

            var balero = await _context.Baleros.FindAsync(id);
            if (balero == null)
            {
                return NotFound();
            }
            return View(balero);
        }

        // POST: Baleros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdBaleros,Marca,Codigo,Precio,FechaCreate")] Balero balero)
        {
            if (id != balero.IdBaleros)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(balero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaleroExists(balero.IdBaleros))
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
            return View(balero);
        }

        // GET: Baleros/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Baleros == null)
            {
                return NotFound();
            }

            var balero = await _context.Baleros
                .FirstOrDefaultAsync(m => m.IdBaleros == id);
            if (balero == null)
            {
                return NotFound();
            }

            return View(balero);
        }

        // POST: Baleros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Baleros == null)
            {
                return Problem("Entity set 'MvcPruebasContext.Baleros'  is null.");
            }
            var balero = await _context.Baleros.FindAsync(id);
            if (balero != null)
            {
                _context.Baleros.Remove(balero);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaleroExists(long id)
        {
          return _context.Baleros.Any(e => e.IdBaleros == id);
        }
    }
}
