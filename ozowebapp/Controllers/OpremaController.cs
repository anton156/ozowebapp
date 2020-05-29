using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ozowebapp.Models;

namespace ozowebapp.Controllers
{
    public class OpremaController : Controller
    {
        private readonly ConnectionStringClass _context;

        public OpremaController(ConnectionStringClass context)
        {
            _context = context;
        }

        // GET: Oprema
        public async Task<IActionResult> Index()
        {
            return View(await _context.Oprema.ToListAsync());
        }

        // GET: Oprema/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opremaClass = await _context.Oprema
                .FirstOrDefaultAsync(m => m.OpremaClassID == id);
            if (opremaClass == null)
            {
                return NotFound();
            }

            return View(opremaClass);
        }

        // GET: Oprema/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Oprema/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OpremaClassID,Naziv,Kolicina,Cijena,Duljina_Koristenja_u_h,Lokacija,Datum_proizvodnje")] OpremaClass opremaClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(opremaClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(opremaClass);
        }

        // GET: Oprema/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opremaClass = await _context.Oprema.FindAsync(id);
            if (opremaClass == null)
            {
                return NotFound();
            }
            return View(opremaClass);
        }

        // POST: Oprema/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OpremaClassID,Naziv,Kolicina,Cijena,Duljina_Koristenja_u_h,Lokacija,Datum_proizvodnje")] OpremaClass opremaClass)
        {
            if (id != opremaClass.OpremaClassID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opremaClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpremaClassExists(opremaClass.OpremaClassID))
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
            return View(opremaClass);
        }

        // GET: Oprema/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opremaClass = await _context.Oprema
                .FirstOrDefaultAsync(m => m.OpremaClassID == id);
            if (opremaClass == null)
            {
                return NotFound();
            }

            return View(opremaClass);
        }

        // POST: Oprema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var opremaClass = await _context.Oprema.FindAsync(id);
            _context.Oprema.Remove(opremaClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpremaClassExists(int id)
        {
            return _context.Oprema.Any(e => e.OpremaClassID == id);
        }
    }
}
