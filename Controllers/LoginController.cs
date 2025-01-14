﻿using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context db = new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Register()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Register(Cari cari)
        {
            db.Caris.Add(cari);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CariLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariLogin(Cari p)
        {
            var bilgiler = db.Caris.FirstOrDefault(x=>x.CariMail==p.CariMail && x.CariSifre == p.CariSifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CariMail"]=bilgiler.CariMail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var bilgiler = db.Admins.FirstOrDefault(x=>x.KullaniciAd==admin.KullaniciAd && x.Sifre==admin.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd, false);
                Session["KullaniciAd"]=bilgiler.KullaniciAd.ToString();
                return RedirectToAction("Index", "İstatistik");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}