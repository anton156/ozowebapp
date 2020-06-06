using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ozowebapp.Models;
using ReflectionIT.Mvc.Paging;

namespace ozowebapp.Controllers
{
    public class UslugaController : Controller
    {
        private readonly ConnectionStringClass _context;

        public UslugaController(ConnectionStringClass context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string search, int page = 1)
        {
            if (!String.IsNullOrEmpty(search))
            {
                var query = _context.UslugaClass.AsNoTracking().Where(x => x.Naziv.Contains(search)).OrderBy(s => s.UslugaClassID);
                var model = await PagingList.CreateAsync(query, 5, page);
                return View(model);
            }
            else
            {
                var query = _context.UslugaClass.AsNoTracking().OrderBy(s => s.UslugaClassID);
                var model = await PagingList.CreateAsync(query, 5, page);
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dodajUslugu = _context.UslugaClass
                .Include(d => d.UslugaToZanimanjes)
                .Include(d => d.UslugaToOpremas)
                .FirstOrDefault(m => m.UslugaClassID == id);
            if (dodajUslugu == null)
            {
                return NotFound();
            }

            return View(dodajUslugu);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var item = _context.Zanimanje.ToList();
            UslugaViewModel m1 = new UslugaViewModel();
            m1.Zanimanja = item.Select(vm => new CheckBoxViewModel()
            {
                ID = vm.ZanimanjeClassID,
                Ime = vm.Naziv,
                MaxKolicina=vm.Kolicina,
            }).ToList(); ;
            var opre = _context.Oprema.ToList();
            m1.Oprema = opre.Select(vmo => new CheckBoxViewModelOprema()
            {
                ID = vmo.OpremaClassID,
                Ime = vmo.Naziv,
                MaxKolicina=vmo.Kolicina,
            }).ToList(); ;
            
            return View(m1);

        }
        [HttpPost]
        public IActionResult Create(UslugaViewModel UVM, PosaoClass posao, UslugaClass usluge,UslugaToZanimanje UZ, UslugaToOprema UP, ZanimanjeClass ZC)
        {
            List<UslugaToZanimanje> utz = new List<UslugaToZanimanje>();
            List<UslugaToOprema> utp = new List<UslugaToOprema>();
            List<PosaoTozanimanje> ptz = new List<PosaoTozanimanje>();
            List<PosaoToOprema> ptp = new List<PosaoToOprema>();

            usluge.Naziv = UVM.Naziv;
            usluge.Cijena = UVM.Cijena;
            usluge.Opis = UVM.Opis;
            usluge.Lokacija = UVM.Lokacija;
            _context.UslugaClass.Add(usluge);
            _context.SaveChanges();

            posao.Naziv = UVM.Naziv;
            posao.Cijena = UVM.Cijena;
            posao.Opis = UVM.Opis;
            posao.Lokacija = UVM.Lokacija;
            posao.Datum_pocetak = DateTime.Now;
            posao.UslugaClassID = usluge.UslugaClassID;
            _context.Posao.Add(posao);
            _context.SaveChanges();

            int uslugaid = usluge.UslugaClassID;
            int posaoid = posao.PosaoClassID;
            foreach (var item in UVM.Zanimanja)
            {
                var oduzmi = _context.Zanimanje.Where(x => item.ID == x.ZanimanjeClassID).ToList();
                foreach (var stock in oduzmi)
                {
                    stock.Kolicina = stock.Kolicina - item.Kolicina;

                }
                if (item.Kolicina > 0)
                {
                    utz.Add(new UslugaToZanimanje() { UslugaClassID = uslugaid, ZanimanjeClassID = item.ID, Kolicina = item.Kolicina, Naziv = item.Ime});
                    ptz.Add(new PosaoTozanimanje() { PosaoClassID = posaoid, ZanimanjeClassID = item.ID, Kolicina = item.Kolicina, Naziv = item.Ime });


                }
            }
            foreach(var item in utz)
            {
                _context.UslugaToZanimanjes.Add(item);

            }
            foreach (var item in ptz)
            {
                _context.PosaoToZanimanjes.Add(item);

            }
            foreach (var item2 in UVM.Oprema)
            {
                var oduzmi = _context.Oprema.Where(x => item2.ID == x.OpremaClassID).ToList();
                foreach (var stock in oduzmi)
                {
                    stock.Kolicina = stock.Kolicina - item2.Kolicina;
                }
                if (item2.Kolicina > 0)
                {
                    utp.Add(new UslugaToOprema() { UslugaClassID = uslugaid, OpremaClassID = item2.ID, Kolicina = item2.Kolicina, Naziv = item2.Ime });
                    ptp.Add(new PosaoToOprema() { PosaoClassID = posaoid, OpremaClassID = item2.ID, Kolicina = item2.Kolicina, Naziv = item2.Ime });
                }
            }
            foreach (var item2 in utp)
            {
                _context.UslugaToOpremas.Add(item2);
            }
            foreach (var item2 in ptp)
            {
                _context.PosaoToOpremas.Add(item2);
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Usluga");
        }

        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    UslugaViewModel UVM = new UslugaViewModel();
        //    var us = _context.UslugaClass.Include(s => s.UslugaToZanimanjes).ThenInclude(e => e.ZanimanjeClass).AsNoTracking().SingleOrDefault(m => m.UslugaClassID == id);
        //    var svazan = _context.Zanimanje.Select(vm => new CheckBoxViewModel()
        //    {
        //        ID = vm.ZanimanjeClassID,
        //        Ime = vm.Naziv,
        //        Checked = vm.UslugaToZanimanjes.Any(x => x.UslugaClassID == us.UslugaClassID) ? true : false
        //    }).ToList();
        //    UVM.Naziv = us.Naziv;
        //    UVM.Cijena = us.Cijena;
        //    UVM.Opis = us.Opis;
        //    UVM.Lokacija = us.Lokacija;
        //    UVM.Zanimanja = svazan;
        //    return View(UVM);
        //}
        //[HttpPost]
        //public IActionResult Edit(UslugaViewModel UVM, UslugaClass usluge, UslugaToZanimanje UZ)
        //{
        //    List<UslugaToZanimanje> utz = new List<UslugaToZanimanje>();
        //    usluge.Naziv = UVM.Naziv;
        //    usluge.Cijena = UVM.Cijena;
        //    usluge.Opis = UVM.Opis;
        //    usluge.Lokacija = UVM.Lokacija;
        //    _context.UslugaClass.Update(usluge);
        //    _context.SaveChanges();

        //    int uslugaid = usluge.UslugaClassID;

        //    foreach (var item in UVM.Zanimanja)
        //    {
        //        if (item.Checked == true)
        //        {
        //            utz.Add(new UslugaToZanimanje() { UslugaClassID = uslugaid, ZanimanjeClassID = item.ID });
        //        }
        //    }

        //    foreach (var item in utz)
        //    {
        //        _context.UslugaToZanimanjes.Add(item);
        //    }

        //    var databasetable = _context.UslugaToZanimanjes.Where(a => a.UslugaClassID == uslugaid).ToList();
        //    var resultlist = databasetable.Except(utz).ToList();
        //    foreach(var item in resultlist)
        //    {
        //        _context.UslugaToZanimanjes.Remove(item);
        //        _context.SaveChanges();
        //    }

        //    var getzanid = _context.UslugaToZanimanjes.Where(a => a.UslugaClassID == uslugaid).ToList();
        //    foreach(var item in utz)
        //    {
        //        if (!getzanid.Contains(item))
        //        {
        //            _context.UslugaToZanimanjes.Add(item);
        //            _context.SaveChanges();
        //        }
        //    }

        //    return RedirectToAction("Index", "Usluga");
        //}
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dodajUslugu = _context.UslugaClass
                .Include(d => d.UslugaToZanimanjes)
                .Include(d => d.UslugaToOpremas)
                .FirstOrDefault(m => m.UslugaClassID == id);
            if (dodajUslugu == null)
            {
                return NotFound();
            }

            return View(dodajUslugu);
        }
        [HttpPost, ActionName("Delete")]
        
        public IActionResult DeleteConfirmed(int id)
        {
            var uslugaClass =  _context.UslugaClass.Find(id);
            var dodajBrojZan = _context.UslugaToZanimanjes.Where(x => uslugaClass.UslugaClassID == x.UslugaClassID).ToList();
            foreach (var item in dodajBrojZan) {
                var DodajZanimanje = _context.Zanimanje.Where(x => item.ZanimanjeClassID == x.ZanimanjeClassID).ToList();
                foreach (var stock in DodajZanimanje)
                {
                    stock.Kolicina = stock.Kolicina + item.Kolicina;
                }
            }
            var dodajBrojOpr = _context.UslugaToOpremas.Where(x => uslugaClass.UslugaClassID == x.UslugaClassID).ToList();
            foreach (var item in dodajBrojOpr)
            {
                var DodajOpremu = _context.Oprema.Where(x => item.OpremaClassID == x.OpremaClassID).ToList();
                foreach (var stock in DodajOpremu)
                {
                    stock.Kolicina = stock.Kolicina + item.Kolicina;
                }
            }

            //Dodajemo datum zavrsetka usluge
            var nadjiID = _context.Posao.Where(x => uslugaClass.UslugaClassID == x.UslugaClassID).ToList();
            foreach (var item in nadjiID)
            {
                item.Datum_kraj = DateTime.Now;
                _context.Posao.Update(item);
                _context.SaveChanges();
            }

            _context.UslugaClass.Remove(uslugaClass);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}