using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        Context db = new Context();
        // GET: Satis
        public ActionResult Index()
        {
            var degerler = db.SatisHarekets.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> urunler = (from x in db.Uruns.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.UrunAd,
                                                Value = x.UrunId.ToString()
                                            }).ToList();
            ViewBag.urunlist = urunler;

            List<SelectListItem> cariler = (from x in db.Caris.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CariAd+ " " + x.CariSoyad,
                                                Value = x.CariId.ToString()
                                            }).ToList();
            ViewBag.carilist = cariler;

            List<SelectListItem> personeller = (from x in db.Personels.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.PersonelAd+" "+ x.PersonelSoyad,
                                                Value = x.PersonelId.ToString()
                                            }).ToList();
            ViewBag.personellist = personeller;


            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(SatisHareket satisHareket)
        {
            satisHareket.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.SatisHarekets.Add(satisHareket);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> urunler = (from x in db.Uruns.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.UrunAd,
                                                Value = x.UrunId.ToString()
                                            }).ToList();
            ViewBag.urunlist = urunler;

            List<SelectListItem> cariler = (from x in db.Caris.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CariAd + " " + x.CariSoyad,
                                                Value = x.CariId.ToString()
                                            }).ToList();
            ViewBag.carilist = cariler;

            List<SelectListItem> personeller = (from x in db.Personels.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                    Value = x.PersonelId.ToString()
                                                }).ToList();
            ViewBag.personellist = personeller;

            var satisgetir = db.SatisHarekets.Find(id);
            return View(satisgetir);
        }

        public ActionResult SatisGuncelle (SatisHareket satisHareket)
        {
            var degerler = db.SatisHarekets.Find(satisHareket.SatisId);
            degerler.UrunId = satisHareket.UrunId;
            degerler.CariId = satisHareket.CariId;
            degerler.PersonelId = satisHareket.PersonelId;
            degerler.Adet = satisHareket.Adet;
            degerler.Fiyat = satisHareket.Fiyat;
            degerler.ToplamTutar = satisHareket.ToplamTutar;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisDetay(int id)
        {
            var degerler = db.SatisHarekets.Where(x=>x.SatisId== id).ToList();
            return View(degerler);
        }
    }
}