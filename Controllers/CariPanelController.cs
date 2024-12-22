using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        Context db = new Context();
        [Authorize]
        // GET: CariPanel
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = db.Caris.FirstOrDefault(x=>x.CariMail == mail);
            ViewBag.m = mail;
            return View(degerler);
        }
    }
}