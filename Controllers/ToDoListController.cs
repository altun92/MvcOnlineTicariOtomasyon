using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ToDoListController : Controller
    {
        Context db = new Context();
        // GET: ToDoList
        public ActionResult Index()
        {
            ViewBag.toplamYapilacak = db.ToDoLists.Count();
            ViewBag.tamamlananYapilacak = db.ToDoLists.Where(x=>x.Durum==true).Count();
            ViewBag.tamamlanmayanYapilacak = db.ToDoLists.Where(x => x.Durum == false).Count();
            ViewBag.kullaniciSayisi = db.Personels.Count();

            var liste = db.ToDoLists.ToList();
            return View(liste);
        }

        public ActionResult CreateToDoList(ToDoList toDoList)
        {
            toDoList.Durum = false;
            db.ToDoLists.Add(toDoList);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult StatusToTrue(int id)
        {
            var deger = db.ToDoLists.Find(id);
            deger.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult StatusToFalse(int id)
        {
            var deger2 = db.ToDoLists.Find(id);
            deger2.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}