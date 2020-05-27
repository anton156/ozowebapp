using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ozowebapp.Models;
using ReflectionIT.Mvc.Paging;

namespace ozowebapp.Controllers
{
    public class DjelatniciController : Controller
    {
        private readonly ConnectionStringClass _context;

        public DjelatniciController(ConnectionStringClass context)
        {
            _context = context;
        }

        // GET: DodajDjelatnikas
        public async Task<IActionResult> Index(string search, int page = 1)
        {
            if (!String.IsNullOrEmpty(search))
            {
                var query = _context.Djelatnik.AsNoTracking().Where(x => x.Ime.Contains(search)).OrderBy(s => s.ID);
                var model = await PagingList.CreateAsync(query, 5, page);
                return View(model);
            }
            else
            {
                var query = _context.Djelatnik.AsNoTracking().OrderBy(s => s.ID);
                var model = await PagingList.CreateAsync(query, 5, page);
                return View(model);
            }
        }

        // GET: DodajDjelatnikas/Details/5
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

        // GET: DodajDjelatnikas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DodajDjelatnikas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ime,Prezime,Zanimanje,Email,Datum_rodjenja,JMBG,Opis,Usluga_ID,Natjecaj_ID")] DjelatnikClass dodajDjelatnika)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dodajDjelatnika);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dodajDjelatnika);
        }

        // GET: DodajDjelatnikas/Edit/5
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

        // POST: DodajDjelatnikas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ime,Prezime,Zanimanje,Email,Datum_rodjenja,JMBG,Opis,Usluga_ID,Natjecaj_ID")] DjelatnikClass dodajDjelatnika)
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

        // GET: DodajDjelatnikas/Delete/5
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

        // POST: DodajDjelatnikas/Delete/5
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
