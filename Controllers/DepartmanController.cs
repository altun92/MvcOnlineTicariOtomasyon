using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        Context db = new Context();
        // GET: Departman
        public ActionResult Index()
        {
            var degerler = db.Departmans.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }

        public ActionResult DepartmanEkle(Departman departman)
        {
            departman.Durum = true;
            db.Departmans.Add(departman);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var degersil = db.Departmans.Find(id);
            degersil.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var dep = db.Departmans.Find(id);
            return View("DepartmanGetir",dep);
        }

        public ActionResult DepartmanGuncelle(Departman d)
        {
            var dept = db.Departmans.Find(d.DepartmanId);
            dept.DepartmanAd = d.DepartmanAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var departmanid = db.Departmans.Find(id);
            ViewBag.departmanad = departmanid.DepartmanAd.ToString();

            var degerler = db.Personels.Where(x => x.DepartmanId == id).ToList();
            return View(degerler);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var satispersonelad = db.Personels.Find(id);
            ViewBag.dper = satispersonelad.PersonelAd.ToString();

            var satislar = db.SatisHarekets.Where(x=>x.PersonelId == id).ToList();
            return View(satislar);
        }
    }
}