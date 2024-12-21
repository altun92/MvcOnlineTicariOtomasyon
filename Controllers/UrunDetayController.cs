using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        Context db = new Context();
        // GET: UrunDetay
        public ActionResult Index()
        {
            UrunDetayViewModel model = new UrunDetayViewModel();
            model.Deger1 = db.Uruns.Where(x=>x.UrunId==1).ToList();
            model.Deger2 = db.Detays.Where(x => x.DetayId == 1).ToList();
            //var degerler = db.Uruns.Where(x=>x.UrunId==1).ToList();
            return View(model);
        }
    }
}