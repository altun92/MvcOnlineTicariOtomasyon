using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
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

            return View();
        }
    }
}