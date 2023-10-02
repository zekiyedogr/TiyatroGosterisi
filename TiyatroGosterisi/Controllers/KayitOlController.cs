using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiyatroGosterisi.Models.Entity;

namespace TiyatroGosterisi.Controllers
{
    [AllowAnonymous]
    public class KayitOlController : Controller
    {
        // GET: KayitOl
        TiyatroGosterisiEntities db = new TiyatroGosterisiEntities();
        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kayit(Uye p)
        {
            db.Uye.Add(p);
            db.SaveChanges();
            return RedirectToAction("GirisYap", "Login");
        }
    }
}