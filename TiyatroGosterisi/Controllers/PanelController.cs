using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiyatroGosterisi.Models.Entity;
using System.Web.Security;

namespace TiyatroGosterisi.Controllers
{
    public class PanelController : Controller
    {
        TiyatroGosterisiEntities db = new TiyatroGosterisiEntities();
        // GET: Panel
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.Uye.FirstOrDefault(z => z.UyeMail == uyemail);
            return View(degerler);
        }

        [HttpPost]
        public ActionResult Index(Uye p)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.Uye.FirstOrDefault(x => x.UyeMail == kullanici);
            uye.UyeParola = p.UyeParola;
            uye.UyeAdi = p.UyeAdi;
            uye.DgmGunu = p.DgmGunu;
            uye.Cinsiyet = p.Cinsiyet;
            uye.UyeTel = p.UyeTel;
            db.SaveChanges();
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Anasayfa");
        }
    }
}