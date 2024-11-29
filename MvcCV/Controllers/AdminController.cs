using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    
    public class AdminController : Controller
    {
        

        AdminRepository repo=new AdminRepository();
        public ActionResult Index()
        {
            var list = repo.List();

            return View(list);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(TblAdmin p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdmin(int id)
        {
            TblAdmin t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult BringAdmin(int id)
        {
            var adminInfo = repo.Find(x => x.ID == id);
            return View(adminInfo);
        }

        [HttpPost]
        public ActionResult BringAdmin(TblAdmin t)
        {
           
            var admin = repo.Find(x => x.ID == t.ID);
            admin.KullaniciAdi = t.KullaniciAdi;
            admin.Sifre = t.Sifre; 
            repo.TUpdate(admin);
            return RedirectToAction("Index");
        }
    }
}