using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiyatroGosterisi.Models.Entity;

namespace TiyatroGosterisi.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        
        TiyatroGosterisiEntities db = new TiyatroGosterisiEntities();
        public ActionResult Index()
        {
            var oyun = from k in db.Uye select k;
            var deger1 = db.Uye.Count(); ;
            ViewBag.dgr1 = deger1;
            var deger = db.Uye.ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeEkle(Uye p)
        {
            if ( !ModelState.IsValid )
            {
                return View("UyeEkle");
            }
            db.Uye.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult UyeSil(int id)
        {
            var uye = db.Uye.Find(id);
            db.Uye.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index", "Uye");
        }

        public ActionResult UyeGetir(int id)
        {
            var uye = db.Uye.Find(id);
            return View("UyeGetir", uye);
        }

        public ActionResult UyeGuncelle(Uye p)
        {
            var uye = db.Uye.Find(p.UyeId);
            uye.UyeAdi = p.UyeAdi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}