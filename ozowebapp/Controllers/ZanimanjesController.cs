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
    public class ZanimanjesController : Controller
    {
        private readonly ConnectionStringClass _context;

        public ZanimanjesController(ConnectionStringClass context)
        {
            _context = context;
        }

        // GET: Zanimanjes
        public async Task<IActionResult> Index( string search,int page= 1)
        {
          
            if (!String.IsNullOrEmpty(search))
            {
                var query = _context.Zanimanje.AsNoTracking().Where(x => x.Naziv.Contains(search)).OrderBy(s => s.ID);
                var model = await PagingList.CreateAsync(query, 5, page);
                return View(model);
            }
            else
            {
                var query = _context.Zanimanje.AsNoTracking().OrderBy(s => s.ID);
                var model = await PagingList.CreateAsync(query, 5, page);
                return View(model);
            }
        }

        // GET: Zanimanjes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zanimanje = await _context.Zanimanje
                .FirstOrDefaultAsync(m => m.ID == id);
            if (zanimanje == null)
            {
                return NotFound();
            }

            return View(zanimanje);
        }

        // GET: Zanimanjes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zanimanjes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Naziv,Satnica,Opis")] Zanimanje zanimanje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zanimanje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zanimanje);
        }

        // GET: Zanimanjes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zanimanje = await _context.Zanimanje.FindAsync(id);
            if (zanimanje == null)
            {
                return NotFound();
            }
            return View(zanimanje);
        }

        // POST: Zanimanjes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Naziv,Satnica,Opis")] Zanimanje zanimanje)
        {
            if (id != zanimanje.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zanimanje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZanimanjeExists(zanimanje.ID))
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
            return View(zanimanje);
        }

        // GET: Zanimanjes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zanimanje = await _context.Zanimanje
                .FirstOrDefaultAsync(m => m.ID == id);
            if (zanimanje == null)
            {
                return NotFound();
            }

            return View(zanimanje);
        }

        // POST: Zanimanjes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zanimanje = await _context.Zanimanje.FindAsync(id);
            _context.Zanimanje.Remove(zanimanje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZanimanjeExists(int id)
        {
            return _context.Zanimanje.Any(e => e.ID == id);
        }
    }
}
