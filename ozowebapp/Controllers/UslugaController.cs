using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
                Checked = false,
            }).ToList(); ;
            var opre = _context.Oprema.ToList();
            m1.Oprema = opre.Select(vmo => new CheckBoxViewModelOprema()
            {
                ID = vmo.OpremaClassID,
                Ime = vmo.Naziv,
                Checked = false,
            }).ToList(); ;
            
            return View(m1);

        }
        [HttpPost]
        public IActionResult Create(UslugaViewModel UVM, UslugaClass usluge,UslugaToZanimanje UZ, UslugaToOprema UP)
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
                if (item.Checked == true)
                {
                    utz.Add(new UslugaToZanimanje() { UslugaClassID = uslugaid, ZanimanjeClassID = item.ID });
                }
            }
            foreach(var item in utz)
            {
                _context.UslugaToZanimanjes.Add(item);
            }
            foreach (var item2 in UVM.Oprema)
            {
                if (item2.Checked == true)
                {
                    utp.Add(new UslugaToOprema() { UslugaClassID = uslugaid, OpremaClassID = item2.ID });
                }
            }
            foreach (var item2 in utp)
            {
                _context.UslugaToOpremas.Add(item2);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Usluga");
        }
    }
}