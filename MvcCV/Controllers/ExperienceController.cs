using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class ExperienceController : Controller
    {
        // Mvc controller Get ve Post sorunsuz calısır,delete ve put icin ozel ayarlama lazım 

        ExperienceRepository repo=new ExperienceRepository();
        public ActionResult Index()
        {
            var values=repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(TblDeneyimlerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteExperience(int id)
        {
            var experience = repo.Find(x => x.ID == id);
            repo.TDelete(experience);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult BringExperience(int id)
        {
            var experience = repo.Find(x => x.ID == id);
            return View(experience);
        }
        [HttpPost]
        public ActionResult BringExperience(TblDeneyimlerim p)
        {
            var experience = repo.Find(x => x.ID == p.ID);
            experience.Baslik = p.Baslik;
            experience.AltBaslik = p.AltBaslik;
            experience.Tarih = p.Tarih;
            experience.Aciklama = p.Aciklama;
            repo.TUpdate(experience);
            return RedirectToAction("Index");
        }


    }
}