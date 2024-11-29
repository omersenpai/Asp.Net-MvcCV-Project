using MvcCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class SkillsController : Controller
    {
        
        SkillsRepository repo=new SkillsRepository();
        public ActionResult Index()
        {
            var skills = repo.List();
            return View(skills);
        }
        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(TblYeteneklerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSkill(int id)
        {
            var skill = repo.Find(x => x.ID == id);
            repo.TDelete(skill);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult BringSkill(int id)
        {
            var skill = repo.Find(x => x.ID == id);
            return View(skill);
        }
        [HttpPost]
        public ActionResult BringSkill(TblYeteneklerim t)
        {
            var skill = repo.Find(x => x.ID == t.ID);
            skill.Yetenek=t.Yetenek;
            skill.Oran = t.Oran;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}