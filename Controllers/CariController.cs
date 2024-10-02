using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        Context db = new Context();
        // GET: Cari
        public ActionResult Index()
        {
           var cariliste = db.Caris.Where(x=>x.Durum==true).ToList();
            return View(cariliste);
        }

        public ActionResult CariEkle(Cari cari)
        {
            cari.Durum = true;
            db.Caris.Add(cari);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var carisil = db.Caris.Find(id);
            carisil.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var carigetir = db.Caris.Find(id);
            return View("CariGetir",carigetir);
        }

        public ActionResult CariGuncelle(Cari cari)
        {
            if (!ModelState.IsValid) 
            {
                return View("CariGetir");
            }

            var cariguncelle = db.Caris.Find(cari.CariId);
            cariguncelle.CariAd = cari.CariAd;
            cariguncelle.CariSoyad = cari.CariSoyad;
            cariguncelle.CariSehir = cari.CariSehir;
            cariguncelle.CariMail = cari.CariMail;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult MusteriSatis(int id)
        {
            var cariad = db.Caris.Find(id);
            ViewBag.cariad = cariad.CariAd + " " + cariad.CariSoyad;

            var carisatis = db.SatisHarekets.Where(x=>x.CariId==id).ToList();
            return View(carisatis);
        }
    }
}