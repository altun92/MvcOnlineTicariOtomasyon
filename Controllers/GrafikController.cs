using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            var grafikciz = new Chart(width: 600, height: 600);
            grafikciz.AddTitle("Kategori - Ürün Stok Sayısı").AddLegend("Stok").
                AddSeries("Değerler", xValue: new[] { "Mobilya", "Ofis Eşyaları", "Bilgisayar" }, yValues: new[] { 85, 66, 98 }).Write();

            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }
        Context db = new Context();
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();

            var sonuclar = db.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.UrunAd));
            sonuclar.ToList().ForEach(y => yvalue.Add(y.Stok));

            var grafik = new Chart(width:500, height:500).AddTitle("Stoklar").AddSeries(chartType:"Column",name:"Stok",xValue:xvalue, yValues:yvalue).Write();
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult()
        {
            return Json(Urunlistesi(), JsonRequestBehavior.AllowGet);
        }

        public List<UrunStokChart> Urunlistesi()
        {
            List<UrunStokChart> urnstk = new List<UrunStokChart>();
            using (var context = new Context())
            {
                urnstk = context.Uruns.Select(x => new UrunStokChart
                {
                    urunad = x.UrunAd,
                    stok = x.Stok
                }).ToList();
            }

            return urnstk;
        }
    }
}