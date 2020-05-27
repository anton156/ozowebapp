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
    public class DodajDjelatnikaController : Controller
    {
        private readonly ConnectionStringClass _context;

        public DodajDjelatnikaController(ConnectionStringClass context)
        {
            _context = context;
        }

        // GET: DodajDjelatnika
        public async Task<IActionResult> Index()
        {
            return View(await _context.Djelatnik.ToListAsync());
        }

        // GET: DodajDjelatnika/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dodajDjelatnika = await _context.Djelatnik
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dodajDjelatnika == null)
            {
                return NotFound();
            }

            return View(dodajDjelatnika);
        }

        // GET: DodajDjelatnika/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DodajDjelatnika/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ime,Prezime,Zanimanje,Email,Datum_rodjenja,JMBG,Opis,Usluga_ID,Natjecaj_ID")] DodajDjelatnika dodajDjelatnika)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dodajDjelatnika);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dodajDjelatnika);
        }

        // GET: DodajDjelatnika/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dodajDjelatnika = await _context.Djelatnik.FindAsync(id);
            if (dodajDjelatnika == null)
            {
                return NotFound();
            }
            return View(dodajDjelatnika);
        }

        // POST: DodajDjelatnika/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ime,Prezime,Zanimanje,Email,Datum_rodjenja,JMBG,Opis,Usluga_ID,Natjecaj_ID")] DodajDjelatnika dodajDjelatnika)
        {
            if (id != dodajDjelatnika.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dodajDjelatnika);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DodajDjelatnikaExists(dodajDjelatnika.ID))
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
            return View(dodajDjelatnika);
        }

        // GET: DodajDjelatnika/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dodajDjelatnika = await _context.Djelatnik
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dodajDjelatnika == null)
            {
                return NotFound();
            }

            return View(dodajDjelatnika);
        }

        // POST: DodajDjelatnika/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dodajDjelatnika = await _context.Djelatnik.FindAsync(id);
            _context.Djelatnik.Remove(dodajDjelatnika);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DodajDjelatnikaExists(int id)
        {
            return _context.Djelatnik.Any(e => e.ID == id);
        }
    }
}
