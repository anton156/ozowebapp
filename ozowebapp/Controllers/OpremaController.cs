using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ozowebapp.Models;

namespace ozowebapp.Controllers
{
    public class OpremaController : Controller
    {
        private readonly ConnectionStringClass _cc;
        public OpremaController(ConnectionStringClass cc)
        {
            _cc = cc;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DodajOpremu()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DodajOpremu(DodajOpremu ec)
        {
            _cc.Add(ec);
            _cc.SaveChanges();
            ViewBag.message = "Uspješna pohrana";
            return View();
        }
    }
}