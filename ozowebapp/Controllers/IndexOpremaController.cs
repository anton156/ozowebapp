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
    public class IndexOpremaController : Controller
    {
        private readonly ConnectionStringClass _context;

        public IndexOpremaController(ConnectionStringClass context)
        {
            _context = context;
        }

        // GET: IndexOprema
        public async Task<IActionResult> Index(int page=1)
        {
            var query = _context.Oprema.AsNoTracking().OrderBy(s => s.ID);
            var model = await PagingList.CreateAsync(query, 5, page);
            return View(model);
        }

        // GET: IndexOprema/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dodajOpremu = await _context.Oprema
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dodajOpremu == null)
            {
                return NotFound();
            }

            return View(dodajOpremu);
        }

        // GET: IndexOprema/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IndexOprema/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Naziv,Kolicina,Cijena,Duljina_Koristenja_u_h,Lokacija,Datum_proizvodnje,Usluga_ID,Natjecaj_ID")] DodajOpremu dodajOpremu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dodajOpremu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dodajOpremu);
        }

        // GET: IndexOprema/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dodajOpremu = await _context.Oprema.FindAsync(id);
            if (dodajOpremu == null)
            {
                return NotFound();
            }
            return View(dodajOpremu);
        }

        // POST: IndexOprema/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Naziv,Kolicina,Cijena,Duljina_Koristenja_u_h,Lokacija,Datum_proizvodnje,Usluga_ID,Natjecaj_ID")] DodajOpremu dodajOpremu)
        {
            if (id != dodajOpremu.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dodajOpremu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DodajOpremuExists(dodajOpremu.ID))
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
            return View(dodajOpremu);
        }

        // GET: IndexOprema/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dodajOpremu = await _context.Oprema
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dodajOpremu == null)
            {
                return NotFound();
            }

            return View(dodajOpremu);
        }

        // POST: IndexOprema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dodajOpremu = await _context.Oprema.FindAsync(id);
            _context.Oprema.Remove(dodajOpremu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DodajOpremuExists(int id)
        {
            return _context.Oprema.Any(e => e.ID == id);
        }
    }
}
