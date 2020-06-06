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
    public class PosaoController : Controller
    {
        private readonly ConnectionStringClass _context;

        public PosaoController(ConnectionStringClass context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string search, int page = 1)
        {
            if (!String.IsNullOrEmpty(search))
            {
                var query = _context.Posao.AsNoTracking().Where(x => x.Naziv.Contains(search)).OrderBy(s => s.PosaoClassID);
                var model = await PagingList.CreateAsync(query, 5, page);
                return View(model);
            }
            else
            {
                var query = _context.Posao.AsNoTracking().OrderBy(s => s.PosaoClassID);
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

            var posaoarhiva = _context.Posao
                .Include(d => d.PosaoToZanimanjes)
                .Include(d => d.PosaoToOpremas)
                .FirstOrDefault(m => m.PosaoClassID == id);
            if (posaoarhiva == null)
            {
                return NotFound();
            }

            return View(posaoarhiva);
        }

    }
}
