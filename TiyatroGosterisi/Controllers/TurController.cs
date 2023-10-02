using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiyatroGosterisi.Models.Entity;

namespace TiyatroGosterisi.Controllers
{
    public class TurController : Controller
    {
        TiyatroGosterisiEntities db = new TiyatroGosterisiEntities();
        public ActionResult Index()
        {
            var deger = db.Tur.ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult TurEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TurEkle(Tur p)
        {
            db.Tur.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult TurSil(int id)
        {
            var tur = db.Tur.Find(id);
            db.Tur.Remove(tur);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult TurGetir(int id)
        {
            var tur = db.Tur.Find(id);
            return View("TurGetir", tur);
        }

        public ActionResult TurGuncelle(Tur p)
        {
            var tur = db.Tur.Find(p.TurId);
            tur.TurAdi = p.TurAdi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}