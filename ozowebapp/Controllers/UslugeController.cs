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
    public class UslugeController : Controller
    {
        private readonly ConnectionStringClass _context;

        public UslugeController(ConnectionStringClass context)
        {
            _context = context;
        }

        // GET: Usluge
        public async Task<IActionResult> Index()
        {
            return View(await _context.UslugaClass.ToListAsync());
        }

        // GET: Usluge/Details/5
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

        // GET: Usluge/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usluge/Create
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

        // GET: Usluge/Edit/5
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
            MyViewModel.Opis = uslugaClass.Opis;
            MyViewModel.Cijena = uslugaClass.Cijena;
            MyViewModel.Lokacija = uslugaClass.Lokacija;

            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { ID = item.ZanimanjeClassID, Ime = item.Naziv, Checked = item.Checked });
            }
            MyViewModel.Zanimanja = MyCheckBoxList;
            return View(MyViewModel);
        }

        // POST: Usluge/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UslugaViewModel uslugaClass)
        {
            if (id != uslugaClass.UslugaClassID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var MojaUsluga = _context.UslugaClass.Find(uslugaClass.UslugaClassID);

                    MojaUsluga.Naziv = uslugaClass.Naziv;

                    foreach (var item in _context.UslugaToZanimanjes)
                    {
                        if (item.UslugaClassID == uslugaClass.UslugaClassID)
                        {
                            _context.Entry(item).State = EntityState.Deleted;
                        }
                    }

                    foreach (var item in uslugaClass.Zanimanja)
                    {
                        if (item.Checked)
                        {
                            _context.UslugaToZanimanjes.Add(new UslugaToZanimanje() { UslugaClassID = uslugaClass.UslugaClassID, ZanimanjeClassID = item.ID });
                        }
                    }

                    _context.Update(uslugaClass);
                    _context.SaveChanges();

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
                return RedirectToAction("Index");

            }

            return View(uslugaClass);
        }

        // GET: Usluge/Delete/5
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

        // POST: Usluge/Delete/5
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
