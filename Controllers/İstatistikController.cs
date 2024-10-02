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
        // GET: İstatistik
        public ActionResult Index()
        {
            ViewBag.toplamUrunSayisi = db.Uruns.Count();
            return View();
        }
    }
}