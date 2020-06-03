using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using ozowebapp.Models;

namespace ozowebapp.Controllers
{
    public class UslugaController : Controller
    {
        private readonly ConnectionStringClass _context;

        public UslugaController(ConnectionStringClass context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var item = _context.UslugaClass.ToList();
            return View(item);
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
            }).ToList(); ;
            var opre = _context.Oprema.ToList();
            m1.Oprema = opre.Select(vmo => new CheckBoxViewModelOprema()
            {
                ID = vmo.OpremaClassID,
                Ime = vmo.Naziv,
            }).ToList(); ;
            
            return View(m1);

        }
        [HttpPost]
        public IActionResult Create(UslugaViewModel UVM, UslugaClass usluge,UslugaToZanimanje UZ, UslugaToOprema UP, ZanimanjeClass ZC)
        {
            List<UslugaToZanimanje> utz = new List<UslugaToZanimanje>();
            List<UslugaToOprema> utp = new List<UslugaToOprema>();
            usluge.Naziv = UVM.Naziv;
            usluge.Cijena = UVM.Cijena;
            usluge.Opis = UVM.Opis;
            usluge.Lokacija = UVM.Lokacija;
            _context.UslugaClass.Add(usluge);
            _context.SaveChanges();
            int uslugaid = usluge.UslugaClassID;
            foreach(var item in UVM.Zanimanja)
            {
                if (item.Kolicina > 0)
                {
                    utz.Add(new UslugaToZanimanje() { UslugaClassID = uslugaid, ZanimanjeClassID = item.ID, Kolicina = item.Kolicina});
                    
                }
            }
            foreach(var item in utz)
            {
                _context.UslugaToZanimanjes.Add(item);
               
            }
            foreach (var item2 in UVM.Oprema)
            {
                if (item2.Kolicina > 0)
                {
                    utp.Add(new UslugaToOprema() { UslugaClassID = uslugaid, OpremaClassID = item2.ID, Kolicina = item2.Kolicina });
                }
            }
            foreach (var item2 in utp)
            {
                _context.UslugaToOpremas.Add(item2);
            }
            _context.SaveChanges();

            foreach (var item in utz)
            {

                var OduzmiKolicinu = _context.Zanimanje.Where(x => UZ.ZanimanjeClassID == x.ZanimanjeClassID).ToList();
                foreach (var stock in OduzmiKolicinu)
                {
                    stock.Kolicina = stock.Kolicina - item.Kolicina;
                }

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
    }
}