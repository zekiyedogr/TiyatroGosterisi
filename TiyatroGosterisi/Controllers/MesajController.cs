using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiyatroGosterisi.Models.Entity;

namespace TiyatroGosterisi.Controllers
{
    public class MesajController : Controller
    {
        // GET: Mesaj
        TiyatroGosterisiEntities db = new TiyatroGosterisiEntities();
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var oyun = from k in db.Mesajlar select k;
            var deger1 = db.Mesajlar.Count(x => x.Alici == uyemail.ToString()); ;
            ViewBag.dgr1 = deger1;
            var mesajlar = db.Mesajlar.Where(x => x.Alici == uyemail.ToString()).ToList();
            return View(mesajlar);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar t)
        {
            var uyemail = (string)Session["Mail"].ToString();
            t.Gonderen = uyemail.ToString();
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Mesajlar.Add(t);
            db.SaveChanges();
            return RedirectToAction("Giden", "Mesaj");
        }

        public ActionResult Giden()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var oyun = from k in db.Mesajlar select k;
            var deger1 = db.Mesajlar.Count(x => x.Gonderen == uyemail.ToString()); ;
            ViewBag.dgr1 = deger1;
            var mesajlar = db.Mesajlar.Where(x => x.Gonderen == uyemail.ToString()).ToList();
            return View(mesajlar);
        }
    }
}