using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ozowebapp.Models;
using ReflectionIT.Mvc.Paging;

namespace ozowebapp.Controllers
{
    public class ArhivaNatjecajiController : Controller
    {
        private readonly ConnectionStringClass _context;

        public ArhivaNatjecajiController(ConnectionStringClass context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string search, int page = 1)
        {
            if (!String.IsNullOrEmpty(search))
            {
                var query = _context.ArhivaNatjecaj.AsNoTracking().Where(x => x.Naziv.Contains(search)).OrderBy(s => s.ArhivaNatjecajClassID);
                var model = await PagingList.CreateAsync(query, 5, page);
                return View(model);
            }
            else
            {
                var query = _context.ArhivaNatjecaj.AsNoTracking().OrderBy(s => s.ArhivaNatjecajClassID);
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

            var dodajNatjecaj = _context.ArhivaNatjecaj
                .Include(d => d.ArhivaNatjecajToZanimanjes)
                .Include(d => d.ArhivaNatjecajToOpremas)
                .FirstOrDefault(m => m.ArhivaNatjecajClassID == id);
            if (dodajNatjecaj == null)
            {
                return NotFound();
            }

            return View(dodajNatjecaj);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            ArhivaNatjecajViewModel m1 = new ArhivaNatjecajViewModel();
            

            return View(m1);
        }
        [HttpPost]
        public IActionResult Edit(int id,ArhivaNatjecajViewModel avm)
        {
            var arhiva = _context.ArhivaNatjecaj.Find(id);
            arhiva.Pobjednik = avm.Pobjednik;
            arhiva.Zakljucak = avm.Zakljucak;
            _context.ArhivaNatjecaj.Update(arhiva);
            _context.SaveChanges();
            return RedirectToAction("Index", "ArhivaNatjecaji");
        }
    }
}
