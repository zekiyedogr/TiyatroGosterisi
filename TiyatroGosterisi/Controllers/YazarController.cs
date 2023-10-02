using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiyatroGosterisi.Models.Entity;

namespace TiyatroGosterisi.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        TiyatroGosterisiEntities db = new TiyatroGosterisiEntities();
        public ActionResult Index()
        {
            var deger = new List<Yazar>();
            using(TiyatroGosterisiEntities db = new TiyatroGosterisiEntities())
            {
                deger = db.Yazar.ToList();
            }
            return View(deger);
        }

        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YazarEkle(Yazar p)
        {
            db.Yazar.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult YazarSil(int id)
        {
            var yzr = db.Yazar.Find(id);
            db.Yazar.Remove(yzr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarGetir(int id)
        {
            var yzr = db.Yazar.Find(id);
            return View("YazarGetir", yzr);
        }

        public ActionResult YazarGuncelle(Yazar p)
        {
            var yzr = db.Yazar.Find(p.YazarId);
            yzr.YazarAdi = p.YazarAdi;
            yzr.YazarOdulSay = p.YazarOdulSay;
            yzr.YazarEserSay = p.YazarEserSay;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}