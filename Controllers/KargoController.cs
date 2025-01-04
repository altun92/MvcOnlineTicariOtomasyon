using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        Context db = new Context();
        // GET: Kargo
        public ActionResult Index(string p)
        {
            var kargolar = from x in db.KargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                kargolar = kargolar.Where(x => x.TakipKodu.Contains(p)); 
            } 
            return View(kargolar.ToList());
        }

        [HttpGet]
        public ActionResult KargoEkle()
        {
            Random rnd = new Random();
            string[] karakterler = { "A", "B", "C", "D", "E" };
            int k1, k2, k3;
            k1= rnd.Next(0, 4);
            k2= rnd.Next(0, 4);
            k3= rnd.Next(0, 4);

            int s1, s2, s3;
            s1 = rnd.Next(100,1000);
            s2 = rnd.Next(10,99);
            s3 = rnd.Next(10,99);

            string kod = s1.ToString() + karakterler[k1] + s2 + karakterler[k2] + s3 + karakterler[k3];
            ViewBag.takipkod = kod;

            return View();
        }

        [HttpPost]
        public ActionResult KargoEkle(KargoDetay kargoDetay)
        {
            try
            {
                kargoDetay.Tarih = DateTime.Now;
                db.KargoDetays.Add(kargoDetay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                Console.WriteLine("Hata oluştu" + ex.Message);
                return View();
            }
            
        }

        public ActionResult KargoDetay(string id)
        {

            var degerler = db.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(degerler);
        }
    }
}