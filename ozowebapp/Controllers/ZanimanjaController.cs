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
    public class ZanimanjaController : Controller
    {
        private readonly ConnectionStringClass _context;

        public ZanimanjaController(ConnectionStringClass context)
        {
            _context = context;
        }

        // GET: Zanimanja
        public async Task<IActionResult> Index(string search, int page = 1)
        {
            if (!String.IsNullOrEmpty(search))
            {
                var query = _context.Zanimanje.AsNoTracking().Where(x => x.Naziv.Contains(search)).OrderBy(s => s.ZanimanjeClassID);
                var model = await PagingList.CreateAsync(query, 5, page);
                return View(model);
            }
            else
            {
                var query = _context.Zanimanje.AsNoTracking().OrderBy(s => s.ZanimanjeClassID);
                var model = await PagingList.CreateAsync(query, 5, page);
                return View(model);
            }
        }

        // GET: Zanimanja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zanimanje = await _context.Zanimanje
                .FirstOrDefaultAsync(m => m.ZanimanjeClassID == id);
            if (zanimanje == null)
            {
                return NotFound();
            }

            return View(zanimanje);
        }

        // GET: Zanimanja/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zanimanja/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZanimanjeClassID,Naziv,Satnica,Opis")] ZanimanjeClass zanimanjeClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zanimanjeClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zanimanjeClass);
        }

        // GET: Zanimanja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zanimanjeClass = await _context.Zanimanje.FindAsync(id);
            if (zanimanjeClass == null)
            {
                return NotFound();
            }
            return View(zanimanjeClass);
        }

        // POST: Zanimanja/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZanimanjeClassID,Naziv,Satnica,Opis")] ZanimanjeClass zanimanjeClass)
        {
            if (id != zanimanjeClass.ZanimanjeClassID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zanimanjeClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZanimanjeClassExists(zanimanjeClass.ZanimanjeClassID))
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
            return View(zanimanjeClass);
        }

        // GET: Zanimanja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zanimanjeClass = await _context.Zanimanje
                .FirstOrDefaultAsync(m => m.ZanimanjeClassID == id);
            if (zanimanjeClass == null)
            {
                return NotFound();
            }

            return View(zanimanjeClass);
        }

        // POST: Zanimanja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zanimanjeClass = await _context.Zanimanje.FindAsync(id);
            _context.Zanimanje.Remove(zanimanjeClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZanimanjeClassExists(int id)
        {
            return _context.Zanimanje.Any(e => e.ZanimanjeClassID == id);
        }
    }
}
