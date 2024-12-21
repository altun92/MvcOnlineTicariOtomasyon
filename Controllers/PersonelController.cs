using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        Context db = new Context();
        // GET: Personel
        public ActionResult Index()
        {
            var personelliste = db.Personels.ToList();
            return View(personelliste);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> list = (from x in db.Departmans.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.DepartmanAd,
                                             Value = x.DepartmanId.ToString(),
                                         }).ToList();
            ViewBag.dpt1 = list;

            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel personel) 
        {
            db.Personels.Add(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelSatislar(int id)
        {
            var personel = db.Personels.Find(id);
            ViewBag.perad = personel.PersonelAd + " " + personel.PersonelSoyad;

            var persatis = db.SatisHarekets.Where(x => x.PersonelId == id).ToList();
            return View(persatis);
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> liste = (from x in db.Departmans.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.DepartmanAd,
                                              Value = x.DepartmanId.ToString()
                                          }).ToList();
            ViewBag.depliste=liste;

            var prsgetir = db.Personels.Find(id);
            return View(prsgetir);
        }

        public ActionResult PersonelGuncelle(Personel personel)
        {
            var degerler = db.Personels.Find(personel.PersonelId);
            degerler.PersonelAd = personel.PersonelAd;
            degerler.PersonelSoyad = personel.PersonelSoyad;
            degerler.PersonelGorsel = personel.PersonelGorsel;
            degerler.PersonelUnvan = personel.PersonelUnvan;
            degerler.PersonelTel = personel.PersonelTel;
            degerler.PersonelAdres = personel.PersonelAdres;
            degerler.DepartmanId = personel.DepartmanId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelDetay()
        {
            var personeldetay = db.Personels.ToList();
            return View(personeldetay);
        }
    }
}