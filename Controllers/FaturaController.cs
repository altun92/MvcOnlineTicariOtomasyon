using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var liste = context.Faturalars.ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            List<SelectListItem> personellist = (from x in context.Personels.ToList()
                                                 select new  SelectListItem
                                                 {
                                                     Text=x.PersonelAd,
                                                     Value=x.PersonelId.ToString(),
                                                 }).ToList();

            ViewBag.personelsec = personellist;
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Faturalar faturalar)
        {
            context.Faturalars.Add(faturalar);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult FaturaGetir (int id)
        {
            var value = context.Faturalars.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult FaturaGuncelle(Faturalar faturalar)
        {
            var value = context.Faturalars.Find(faturalar.FaturaId);
            value.FaturaSeriNo = faturalar.FaturaSeriNo;
            value.FaturaSıraNo = faturalar.FaturaSıraNo;
            value.Tarih = faturalar.Tarih;
            value.Saat = faturalar.Saat;
            value.VergiDairesi = faturalar.VergiDairesi;
            value.TeslimAlan = faturalar.TeslimAlan;
            value.TeslimEden = faturalar.TeslimEden;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var faturano = context.Faturalars.Find(id);
            ViewBag.faturano = faturano.FaturaSeriNo + "" + faturano.FaturaSıraNo; 

            var degerler = context.FaturaKalems.Where(x=>x.FaturaId == id).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem faturaKalem)
        {
            context.FaturaKalems.Add(faturaKalem);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}