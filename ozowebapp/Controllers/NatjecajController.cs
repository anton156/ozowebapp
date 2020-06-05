using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ozowebapp.Models;
using ReflectionIT.Mvc.Paging;

namespace ozowebapp.Controllers
{
    public class NatjecajController : Controller
    {
        private readonly ConnectionStringClass _context;

        public NatjecajController(ConnectionStringClass context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string search, int page = 1)
        {
            if (!String.IsNullOrEmpty(search))
            {
                var query = _context.Natjecaj.AsNoTracking().Where(x => x.Naziv.Contains(search)).OrderBy(s => s.NatjecajClassID);
                var model = await PagingList.CreateAsync(query, 5, page);
                return View(model);
            }
            else
            {
                var query = _context.Natjecaj.AsNoTracking().OrderBy(s => s.NatjecajClassID);
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

            var dodajNatjecaj = _context.Natjecaj
                .Include(d => d.NatjecajToZanimanjes)
                .Include(d => d.NatjecajToOpremas)
                .FirstOrDefault(m => m.NatjecajClassID == id);
            if (dodajNatjecaj == null)
            {
                return NotFound();
            }

            return View(dodajNatjecaj);
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
                MaxKolicina = vm.Kolicina,
            }).ToList(); ;
            var opre = _context.Oprema.ToList();
            m1.Oprema = opre.Select(vmo => new CheckBoxViewModelOprema()
            {
                ID = vmo.OpremaClassID,
                Ime = vmo.Naziv,
                MaxKolicina = vmo.Kolicina,
            }).ToList(); ;

            return View(m1);

        }
        [HttpPost]
        public IActionResult Create(NatjecajViewModel NVM, NatjecajClass natjecaji, NatjecajToZanimanje NZ, NatjecajToOprema UP, ZanimanjeClass ZC)
        {
            List<NatjecajToZanimanje> utz = new List<NatjecajToZanimanje>();
            List<NatjecajToOprema> utp = new List<NatjecajToOprema>();
            natjecaji.Naziv = NVM.Naziv;
            natjecaji.Cijena = NVM.Cijena;
            natjecaji.Opis = NVM.Opis;
            natjecaji.Lokacija = NVM.Lokacija;
            _context.Natjecaj.Add(natjecaji);
            _context.SaveChanges();
            int natjecajid = natjecaji.NatjecajClassID;
            foreach (var item in NVM.Zanimanja)
            {
                var oduzmi = _context.Zanimanje.Where(x => item.ID == x.ZanimanjeClassID).ToList();
                foreach (var stock in oduzmi)
                {
                    stock.Kolicina = stock.Kolicina - item.Kolicina;

                }
                if (item.Kolicina > 0)
                {
                    utz.Add(new NatjecajToZanimanje() { NatjecajClassID = natjecajid, ZanimanjeClassID = item.ID, Kolicina = item.Kolicina, Naziv = item.Ime });


                }
            }
            foreach (var item in utz)
            {
                _context.NatjecajToZanimanjes.Add(item);

            }
            foreach (var item2 in NVM.Oprema)
            {
                var oduzmi = _context.Oprema.Where(x => item2.ID == x.OpremaClassID).ToList();
                foreach (var stock in oduzmi)
                {
                    stock.Kolicina = stock.Kolicina - item2.Kolicina;
                }
                if (item2.Kolicina > 0)
                {
                    utp.Add(new NatjecajToOprema() { NatjecajClassID = natjecajid, OpremaClassID = item2.ID, Kolicina = item2.Kolicina, Naziv = item2.Ime });
                }
            }
            foreach (var item2 in utp)
            {
                _context.NatjecajToOpremas.Add(item2);
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Natjecaj");
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dodajNatjecaj = _context.Natjecaj
                .Include(d => d.NatjecajToZanimanjes)
                .Include(d => d.NatjecajToOpremas)
                .FirstOrDefault(m => m.NatjecajClassID == id);
            if (dodajNatjecaj == null)
            {
                return NotFound();
            }

            return View(dodajNatjecaj);
        }
        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirmed(int id)
        {
            var natjecajClass = _context.Natjecaj.Find(id);
            var dodajBrojZan = _context.NatjecajToZanimanjes.Where(x => natjecajClass.NatjecajClassID == x.NatjecajClassID).ToList();
            foreach (var item in dodajBrojZan)
            {
                var DodajZanimanje = _context.Zanimanje.Where(x => item.ZanimanjeClassID == x.ZanimanjeClassID).ToList();
                foreach (var stock in DodajZanimanje)
                {
                    stock.Kolicina = stock.Kolicina + item.Kolicina;
                }
            }
            var dodajBrojOpr = _context.NatjecajToOpremas.Where(x => natjecajClass.NatjecajClassID == x.NatjecajClassID).ToList();
            foreach (var item in dodajBrojOpr)
            {
                var DodajOpremu = _context.Oprema.Where(x => item.OpremaClassID == x.OpremaClassID).ToList();
                foreach (var stock in DodajOpremu)
                {
                    stock.Kolicina = stock.Kolicina + item.Kolicina;
                }
            }
            _context.Natjecaj.Remove(natjecajClass);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}