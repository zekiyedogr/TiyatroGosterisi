using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiyatroGosterisi.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace TiyatroGosterisi.Controllers
{
    public class OyuncuController : Controller
    {
        // GET: Oyuncu
        TiyatroGosterisiEntities db = new TiyatroGosterisiEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var oyun = from k in db.Oyuncu select k;
            var deger1 = db.Oyuncu.Count(); ;
            ViewBag.dgr1 = deger1;
            var oyuncu = db.Oyuncu.ToList().ToPagedList(sayfa, 10);
            return View(oyuncu);
        }

        [HttpGet]
        public ActionResult OyuncuEkle()
        {
            List<SelectListItem> deger1 = (from i in db.Oyun.ToList() select new SelectListItem { Text = i.OyunAdi, Value = i.OyunId.ToString() }).ToList();
            ViewBag.dgr1 = deger1;            
            return View();
        }

        [HttpPost]
        public ActionResult OyuncuEkle(Oyuncu p)
        {
            var oyun = db.Oyun.Where(oy => oy.OyunId == p.Oyun.OyunId).FirstOrDefault();
            p.Oyun = oyun;
            db.Oyuncu.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OyuncuSil(int id)
        {
            var oyuncu = db.Oyuncu.Find(id);
            db.Oyuncu.Remove(oyuncu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OyuncuGetir(int id)
        {
            var oyuncu = db.Oyuncu.Find(id);
            List<SelectListItem> deger1 = (from i in db.Oyun.ToList() select new SelectListItem { Text = i.OyunAdi, Value = i.OyunId.ToString() }).ToList();
            ViewBag.dgr1 = deger1;
            return View("OyuncuGetir", oyuncu);
        }

        public ActionResult OyuncuGuncelle(Oyuncu p)
        {
            var oyuncu = db.Oyuncu.Find(p.OyuncuId);
            oyuncu.OyuncuAdi = p.OyuncuAdi;
            var oyn = db.Oyun.Where(oy => oy.OyunId == p.Oyun.OyunId).FirstOrDefault();
            oyuncu.OyunId = oyn.OyunId;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}