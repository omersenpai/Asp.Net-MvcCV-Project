using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class EducationController : Controller
    {
        EducationRepository repo = new EducationRepository();
        
        public ActionResult Index()
        {
            var education = repo.List();
            return View(education);
        }
        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(TblEgitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEducation");
            }
           repo.TAdd(p);
           return RedirectToAction("Index");
        }
        public ActionResult DeleteEducation(int id)
        {
            var education = repo.Find(x => x.ID == id);
            repo.TDelete(education);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult BringEducation(int id)
        {
            var education = repo.Find(x => x.ID == id);
            return View(education);
        }
        [HttpPost]
        public ActionResult BringEducation(TblEgitimlerim t)
        {
            if (!ModelState.IsValid)
            {
                return View("BringEducation");
            }
            var education = repo.Find(x => x.ID == t.ID);
            education.Baslik = t.Baslik;
            education.AltBaslik1 = t.AltBaslik1;
            education.AltBaslik2= t.AltBaslik2;
            education.GNO= t.GNO;
            education.Tarih=t.Tarih;
            repo.TUpdate(education);
            return RedirectToAction("Index");
        }
    }
}