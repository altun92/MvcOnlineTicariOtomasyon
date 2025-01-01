using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class İstatistikController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            ViewBag.toplamUrunSayisi = db.Uruns.Count();

            ViewBag.kategoriSayisi = db.Kategoris.Count();

            ViewBag.cariSayisi = db.Caris.Count();

            ViewBag.personelSayisi = db.Personels.Count();

            ViewBag.toplamStokSayisi = db.Uruns.Sum(x=>x.Stok);

            ViewBag.toplamMarka = (from x in db.Uruns select x.Marka).Distinct().Count().ToString();

            ViewBag.kritikSeviyeUrun = db.Uruns.Count(x=>x.Stok<=20).ToString();

            ViewBag.enYuksekFiyatliUrun = (from x in db.Uruns orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault();

            ViewBag.enDusukFiyatliUrun = (from x in db.Uruns orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault();

            ViewBag.enFazlaMarka = db.Uruns.GroupBy(x=>x.Marka).OrderByDescending(z=>z.Count()).Select(y=>y.Key).FirstOrDefault();

            ViewBag.buzdolabiSayisi = db.Uruns.Count(x=>x.UrunAd=="Buzdolabı").ToString();

            ViewBag.laptopSayisi = db.Uruns.Count(x => x.UrunAd == "Laptop").ToString();

            ViewBag.encokSatanUrun = db.Uruns.Where(u=>u.UrunId==(db.SatisHarekets.GroupBy(x=>x.UrunId).OrderByDescending(z=>z.Count()).Select(y=> y.Key).FirstOrDefault())).Select(k=>k.UrunAd).FirstOrDefault();

            ViewBag.kasadakiTutar = db.SatisHarekets.Sum(x=>x.ToplamTutar).ToString();

            ViewBag.bugunSatisSayisi = db.SatisHarekets.Count(x=>x.Tarih==DateTime.Today).ToString();

            ViewBag.bugünKasaToplam = db.SatisHarekets.Where(x => x.Tarih == DateTime.Today).Sum(y => (decimal?)y.ToplamTutar).ToString();
            return View();
        }

        public ActionResult KolayTablolar()
        {
            var sorgu = from x in db.Caris
                        group x by x.CariSehir into g
                        select new SinifGroup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };

            return View(sorgu.ToList());
        }

        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in db.Personels
                         group x by x.Departman.DepartmanAd into g
                         select new SinifGroup2
                         {
                             Departman = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }

        public PartialViewResult Partial2()
        {
            var sorgu3 = db.Caris.ToList();
            return PartialView(sorgu3);
        }

        public PartialViewResult Partial3()
        {
            var sorgu4 = db.Uruns.ToList();
            return PartialView(sorgu4);
        }
    }
}