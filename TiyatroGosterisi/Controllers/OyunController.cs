using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiyatroGosterisi.Models.Entity;

namespace TiyatroGosterisi.Controllers
{
    public class OyunController : Controller
    {
        // GET: Oyun
        TiyatroGosterisiEntities db = new TiyatroGosterisiEntities();
        public ActionResult Index(string p)
        {
            var oyun = from k in db.Oyun select k;
            var deger1 = db.Oyun.Count();
            ViewBag.dgr1 = deger1;
            if (!string.IsNullOrEmpty(p))
            {
                oyun = oyun.Where(m => m.OyunAdi.Contains(p));
            }
            // var oyun = db.Oyun.ToList();
            return View(oyun.ToList());

        }

        [HttpGet]
        public ActionResult OyunEkle()
        {
            List<SelectListItem> deger1 = (from i in db.Tur.ToList() select new SelectListItem { Text = i.TurAdi, Value = i.TurId.ToString() }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.Yonetmen.ToList() select new SelectListItem { Text = i.YonetmenAdi, Value = i.YonetmenId.ToString() }).ToList();
            ViewBag.dgr2 = deger2;
            List<SelectListItem> deger3 = (from i in db.Yazar.ToList() select new SelectListItem { Text = i.YazarAdi, Value = i.YazarId.ToString() }).ToList();
            ViewBag.dgr3 = deger3;
            return View();
        }

        [HttpPost]
        public ActionResult OyunEkle(Oyun p)
        {
            if (!ModelState.IsValid)
            {
                return View("OyunEkle");
            }
            var tur = db.Tur.Where(oyun => oyun.TurId == p.Tur.TurId).FirstOrDefault();
            var yzr = db.Yazar.Where(oyun => oyun.YazarId == p.Yazar.YazarId).FirstOrDefault();
            var ynt = db.Yonetmen.Where(oyun => oyun.YonetmenId == p.Yonetmen.YonetmenId).FirstOrDefault();
            p.Tur = tur;
            p.Yazar = yzr;
            p.Yonetmen = ynt;
            db.Oyun.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OyunSil(int id)
        {
            var oyun = db.Oyun.Find(id);
            db.Oyun.Remove(oyun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OyunGetir(int id)
        {
            var oyun = db.Oyun.Find(id);
            List<SelectListItem> deger1 = (from i in db.Tur.ToList() select new SelectListItem { Text = i.TurAdi, Value = i.TurId.ToString() }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.Yonetmen.ToList() select new SelectListItem { Text = i.YonetmenAdi, Value = i.YonetmenId.ToString() }).ToList();
            ViewBag.dgr2 = deger2;
            List<SelectListItem> deger3 = (from i in db.Yazar.ToList() select new SelectListItem { Text = i.YazarAdi, Value = i.YazarId.ToString() }).ToList();
            ViewBag.dgr3 = deger3;
            return View("OyunGetir", oyun);
        }

        public ActionResult OyunGuncelle(Oyun p)
        {
            var oyun = db.Oyun.Find(p.OyunId);
            oyun.OyunAdi = p.OyunAdi;
            var ynt = db.Yonetmen.Where(yo => yo.YonetmenId == p.Yonetmen.YonetmenId).FirstOrDefault();
            var yzr = db.Yazar.Where(ya => ya.YazarId == p.Yazar.YazarId).FirstOrDefault();
            var tur = db.Tur.Where(t => t.TurId == p.Tur.TurId).FirstOrDefault();
            oyun.YonetmenId = ynt.YonetmenId;
            oyun.YazarId = yzr.YazarId;
            oyun.TurId = tur.TurId;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}