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
    public class UslugaClassesController : Controller
    {
        private readonly ConnectionStringClass _context;

        public UslugaClassesController(ConnectionStringClass context)
        {
            _context = context;
        }

        // GET: UslugaClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.UslugaClass.ToListAsync());
        }

        // GET: UslugaClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uslugaClass = await _context.UslugaClass
                .FirstOrDefaultAsync(m => m.UslugaClassID == id);
            if (uslugaClass == null)
            {
                return NotFound();
            }

            return View(uslugaClass);
        }

        // GET: UslugaClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UslugaClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UslugaClassID,Naziv,Cijena,Opis,Lokacija")] UslugaClass uslugaClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uslugaClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uslugaClass);
        }

        // GET: UslugaClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uslugaClass = await _context.UslugaClass.FindAsync(id);
            if (uslugaClass == null)
            {
                return NotFound();
            }
            var Results = from b in _context.Zanimanje
                          select new
                          {
                              b.ZanimanjeClassID,
                              b.Naziv,
                              Checked = ((from ab in _context.UslugaToZanimanjes
                                          where (ab.UslugaClassID == id) & (ab.ZanimanjeClassID == b.ZanimanjeClassID)
                                          select ab).Count() > 0)
                          };
            var MyViewModel = new UslugaViewModel();

            MyViewModel.UslugaClassID = id.Value;
            MyViewModel.Naziv = uslugaClass.Naziv;

            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { ID = item.ZanimanjeClassID, Ime = item.Naziv, Checked = item.Checked });
            }
            MyViewModel.Zanimanja = MyCheckBoxList;
            return View(uslugaClass);
        }

        // POST: UslugaClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UslugaClassID,Naziv,Cijena,Opis,Lokacija")] UslugaClass uslugaClass)
        {
            if (id != uslugaClass.UslugaClassID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uslugaClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UslugaClassExists(uslugaClass.UslugaClassID))
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
            return View(uslugaClass);
        }

        // GET: UslugaClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uslugaClass = await _context.UslugaClass
                .FirstOrDefaultAsync(m => m.UslugaClassID == id);
            if (uslugaClass == null)
            {
                return NotFound();
            }

            return View(uslugaClass);
        }

        // POST: UslugaClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uslugaClass = await _context.UslugaClass.FindAsync(id);
            _context.UslugaClass.Remove(uslugaClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UslugaClassExists(int id)
        {
            return _context.UslugaClass.Any(e => e.UslugaClassID == id);
        }
    }
}
