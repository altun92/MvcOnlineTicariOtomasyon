using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            var urunliste = db.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunliste);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> list = (from x in db.Kategoris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.KategoriAd,
                                             Value = x.KategoriId.ToString(),
                                         }).ToList();
            ViewBag.dgr1 = list;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urun urun)
        {
            db.Uruns.Add(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var urunsil = db.Uruns.Find(id);
            urunsil.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> list = (from x in db.Kategoris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.KategoriAd,
                                             Value = x.KategoriId.ToString(),
                                         }).ToList();
            ViewBag.dgr1 = list;

            var urundeger=db.Uruns.Find(id);
            return View("UrunGetir",urundeger);
        }

        public ActionResult UrunGuncelle(Urun urun)
        {
            var urunguncelle = db.Uruns.Find(urun.UrunId);
            urunguncelle.UrunAd = urun.UrunAd;
            urunguncelle.Marka = urun.Marka;
            urunguncelle.Stok = urun.Stok;
            urunguncelle.AlisFiyat=urun.AlisFiyat;
            urunguncelle.SatisFiyat = urun.SatisFiyat;
            urunguncelle.Durum=urun.Durum;
            urunguncelle.UrunGorsel=urun.UrunGorsel;
            urunguncelle.KategoriId=urun.KategoriId;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}