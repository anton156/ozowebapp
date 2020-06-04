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

        // GET: Djelatnici
        public async Task<IActionResult> Index(string search, int page = 1)
        {
            if (!String.IsNullOrEmpty(search))
            {
                var query = _context.Djelatnik.AsNoTracking().Where(x => x.Ime.Contains(search)).Include(d => d.ZanimanjeClass).OrderBy(s => s.DjelatnikClassID);
                var model = await PagingList.CreateAsync(query, 5, page);
                return View(model);
            }
            else
            {
                var query = _context.Djelatnik.AsNoTracking().Include(d => d.ZanimanjeClass).OrderBy(s => s.DjelatnikClassID);
                var model = await PagingList.CreateAsync(query, 5, page);
                return View(model);
            }
            
        }

        // GET: Djelatnici/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dodajDjelatnika = await _context.Djelatnik
                .Include(d => d.ZanimanjeClass)
                .FirstOrDefaultAsync(m => m.DjelatnikClassID == id);
            if (dodajDjelatnika == null)
            {
                return NotFound();
            }

            return View(dodajDjelatnika);
        }

        // GET: Djelatnici/Create
        public IActionResult Create()
        {
            ViewData["ZanimanjeClassID"] = new SelectList(_context.Zanimanje, "ZanimanjeClassID", "Naziv");
            return View();
        }

        // POST: Djelatnici/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DjelatnikClassID,Ime,Prezime,ZanimanjeClassID,Email,Datum_rodjenja")] DjelatnikClass djelatnikClass)
        {
            var DodajZanimanje = _context.Zanimanje.Where(x=>djelatnikClass.ZanimanjeClassID==x.ZanimanjeClassID).ToList();
            foreach(var stock in DodajZanimanje)
            {
                stock.Kolicina = stock.Kolicina + 1;
            }

            if (ModelState.IsValid)
            {
                _context.Add(djelatnikClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ZanimanjeClassID"] = new SelectList(_context.Zanimanje, "ZanimanjeClassID", "Naziv", djelatnikClass.ZanimanjeClassID);
            return View(djelatnikClass);
        }

        // GET: Djelatnici/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var djelatnikClass = await _context.Djelatnik.FindAsync(id);
            if (djelatnikClass == null)
            {
                return NotFound();
            }
            ViewData["ZanimanjeClassID"] = new SelectList(_context.Zanimanje, "ZanimanjeClassID", "Naziv", djelatnikClass.ZanimanjeClassID);
            return View(djelatnikClass);
        }

        // POST: Djelatnici/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DjelatnikClassID,Ime,Prezime,ZanimanjeClassID,Email,Datum_rodjenja")] DjelatnikClass djelatnikClass)
        {
            if (id != djelatnikClass.DjelatnikClassID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(djelatnikClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DjelatnikClassExists(djelatnikClass.DjelatnikClassID))
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
            ViewData["ZanimanjeClassID"] = new SelectList(_context.Zanimanje, "ZanimanjeClassID", "Naziv", djelatnikClass.ZanimanjeClassID);
            return View(djelatnikClass);
        }

        // GET: Djelatnici/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var djelatnikClass = await _context.Djelatnik
                .Include(d => d.ZanimanjeClass)
                .FirstOrDefaultAsync(m => m.DjelatnikClassID == id);
            if (djelatnikClass == null)
            {
                return NotFound();
            }

            return View(djelatnikClass);
        }

        // POST: Djelatnici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var djelatnikClass = await _context.Djelatnik.FindAsync(id);
            var DodajZanimanje = _context.Zanimanje.Where(x => djelatnikClass.ZanimanjeClassID == x.ZanimanjeClassID).ToList();
            foreach (var stock in DodajZanimanje)
            {
                stock.Kolicina = stock.Kolicina - 1;
            }
            _context.Djelatnik.Remove(djelatnikClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DjelatnikClassExists(int id)
        {
            return _context.Djelatnik.Any(e => e.DjelatnikClassID == id);
        }
    }
}
