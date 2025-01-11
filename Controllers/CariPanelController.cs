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

            var mailid = db.Caris.Where(x => x.CariMail == mail).Select(y => y.CariId).FirstOrDefault();
            ViewBag.mailid = mailid;

            var adsoyad = db.Caris.Where(x => x.CariId == mailid).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;

            var toplamsatis = db.SatisHarekets.Where(x => x.CariId == mailid).Count();
            ViewBag.toplamsatis = toplamsatis;

            var tutartopla = db.SatisHarekets.Where(x => x.CariId == mailid).Select(y => (decimal?)y.ToplamTutar).Sum() ?? 0;
            ViewBag.toplamtutar = tutartopla;

            var toplamurun = db.SatisHarekets.Where(x => x.CariId == mailid).Select(y => (int?)y.Adet).Sum() ?? 0;
            ViewBag.toplamurun = toplamurun;

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

        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = db.Mesajlars.Where(x => x.Alıcı == mail).OrderByDescending(y => y.Tarih).ToList();

            var gelenmesaj = db.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.gelenmesajsayisi = gelenmesaj;

            var gidenmesaj = db.Mesajlars.Count(x => x.Gönderici == mail).ToString();
            ViewBag.gidenmesajsayisi = gidenmesaj;

            return View(mesajlar);
        }

        public ActionResult GonderilenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = db.Mesajlars.Where(x => x.Gönderici == mail).ToList();

            var gelenmesaj = db.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.gelenmesajsayisi = gelenmesaj;

            var gidenmesaj = db.Mesajlars.Count(x => x.Gönderici == mail).ToString();
            ViewBag.gidenmesajsayisi = gidenmesaj;

            return View(mesajlar);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];
            var gelenmesaj = db.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.gelenmesajsayisi = gelenmesaj;

            var gidenmesaj = db.Mesajlars.Count(x => x.Gönderici == mail).ToString();
            ViewBag.gidenmesajsayisi = gidenmesaj;

            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar mesajlar)
        {
            var mail = (string)Session["CariMail"];
            mesajlar.Gönderici = mail;
            mesajlar.Tarih = DateTime.Now;
            db.Mesajlars.Add(mesajlar);
            db.SaveChanges();
            return RedirectToAction("GonderilenMesajlar");
        }

        public ActionResult MesajDetaylari(int id)
        {
            var mail = (string)Session["CariMail"];
            var gelenmesaj = db.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.gelenmesajsayisi = gelenmesaj;

            var gidenmesaj = db.Mesajlars.Count(x => x.Gönderici == mail).ToString();
            ViewBag.gidenmesajsayisi = gidenmesaj;

            var mesaj = db.Mesajlars.Find(id);
            return View(mesaj);
        }

        public ActionResult MesajSil(int id)
        {
            var mesaj = db.Mesajlars.Find(id);
            db.Mesajlars.Remove(mesaj);
            db.SaveChanges();
            return RedirectToAction("GelenMesajlar");
        }

        public ActionResult KargoTakip(string p)
        {
            var kargolar = from x in db.KargoDetays select x;
            kargolar = kargolar.Where(x => x.TakipKodu.Contains(p));
            return View(kargolar.ToList());
        }

        public ActionResult KargoDetay(string id)
        {

            var degerler = db.KargoTakips.Where(x => x.TakipKodu == id).ToList();
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