using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        Context db = new Context();
        // GET: CariPanel
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = db.Caris.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.m = mail;
            return View(degerler);
        }

        [HttpPost]
        public ActionResult UpdateCari(Cari cari)
        {
            var bul = db.Caris.Find(cari.CariId);
            cari.CariAd = bul.CariAd;
            cari.CariSoyad = bul.CariSoyad;
            cari.CariSehir = bul.CariSehir;
            cari.CariSifre = bul.CariSifre;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = db.Caris.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariId).FirstOrDefault();
            var degerler = db.SatisHarekets.Where(x => x.CariId == id).ToList();
            return View(degerler);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}