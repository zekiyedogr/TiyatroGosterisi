using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiyatroGosterisi.Models.Entity;

namespace TiyatroGosterisi.Controllers
{
    [AllowAnonymous]
    public class AnasayfaController : Controller
    {
        // GET: Anasayfa
        TiyatroGosterisiEntities db = new TiyatroGosterisiEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Index(Iletisim t)
        {
            db.Iletisim.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}