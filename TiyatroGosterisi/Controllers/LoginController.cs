using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiyatroGosterisi.Models.Entity;
using System.Web.Security;

namespace TiyatroGosterisi.Controllers
{ [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        TiyatroGosterisiEntities db = new TiyatroGosterisiEntities();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(Uye p)
        {
            var bilgiler = db.Uye.FirstOrDefault(x => x.UyeMail == p.UyeMail && x.UyeParola == p.UyeParola);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.UyeMail, false);
                Session["Mail"] = bilgiler.UyeMail.ToString();
                //Session["Adı"] = bilgiler.UyeAdi.ToString();
                //Session["KullanıcıAdı"] = bilgiler.KullaniciAdi.ToString();
                //TempData["Sifre"] = bilgiler.UyeParola.ToString();
                //Session["DogumG"] = bilgiler.DgmGunu.ToString();
                //Session["UyeTel"] = bilgiler.UyeTel.ToString();
                //Session["Cinsiyet"] = bilgiler.Cinsiyet.ToString();
                return RedirectToAction("Index", "Panel");
            }

            else
            {
            return View();
            }
        }
    }
}