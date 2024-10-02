using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        Context db = new Context();
        // GET: Kategori
        public ActionResult Index()
        {
            var kategori = db.Kategoris.ToList();
            return View(kategori);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            db.Kategoris.Add(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var kategorisil = db.Kategoris.Find(id);
            db.Kategoris.Remove(kategorisil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriDuzenle(int id)
        {
            var kategori= db.Kategoris.Find(id);
            return View("KategoriDuzenle",kategori);
        }

        public ActionResult KategoriGuncelle(Kategori kategori)
        {
            var ktgr = db.Kategoris.Find(kategori.KategoriId);
            ktgr.KategoriAd = kategori.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}