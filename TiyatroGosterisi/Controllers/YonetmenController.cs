using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiyatroGosterisi.Models.Entity;

namespace TiyatroGosterisi.Controllers
{
    public class YonetmenController : Controller
    {
        // GET: Yonetmen
        TiyatroGosterisiEntities db = new TiyatroGosterisiEntities();
        public ActionResult Index()
        {
            var deger = db.Yonetmen.ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult YonetmenEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YonetmenEkle(Yonetmen p)
        {
            db.Yonetmen.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult YonetmenSil(int id)
        {
            var ynt = db.Yonetmen.Find(id);
            db.Yonetmen.Remove(ynt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YonetmenGetir(int id)
        {
            var ynt = db.Yonetmen.Find(id);
            return View("YonetmenGetir", ynt);
        }

        public ActionResult YonetmenGuncelle(Yonetmen p)
        {
            var ynt = db.Yonetmen.Find(p.YonetmenId);
            ynt.YonetmenAdi = p.YonetmenAdi;
            ynt.YonetmenOdulSay = p.YonetmenOdulSay;
            ynt.YonetmenEserSay = p.YonetmenEserSay;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}