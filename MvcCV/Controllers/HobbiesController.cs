using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class HobbiesController : Controller
    {
        // GET: Interests
        HobbiesRepository repo=new HobbiesRepository();
        [HttpGet]
        public ActionResult Index()
        {
            var hobbies = repo.List();
            return View(hobbies);
        }
        [HttpPost]
        public ActionResult Index(List<TblHobilerim> hobbies)
        {
            foreach (var hobby in hobbies)
            {
                var existingHobby = repo.Find(x => x.ID == hobby.ID);

                if (existingHobby != null)
                {
                    existingHobby.Aciklama1 = hobby.Aciklama1;
                    existingHobby.Aciklama2 = hobby.Aciklama2;
                    repo.TUpdate(existingHobby);
                }
                else
                {
                    // Eğer ID bulunmuyorsa yeni kayıt eklenir
                    repo.TAdd(new TblHobilerim
                    {
                        Aciklama1 = hobby.Aciklama1,
                        Aciklama2 = hobby.Aciklama2
                    });
                }
            }

            return RedirectToAction("Index");
        }

    }
}