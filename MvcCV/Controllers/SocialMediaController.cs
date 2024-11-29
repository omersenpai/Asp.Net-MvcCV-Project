using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class SocialMediaController : Controller
    {
        SocialMediaRepository repo = new SocialMediaRepository();

        public ActionResult Index()
        {
            var socialMedia = repo.List();
            return View(socialMedia);
        }
        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }
        public ActionResult AddSocialMedia(TblSosyalMedya p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult BringSocialMedia(int id)
        {
            var account=repo.Find(x=>x.ID==id);
            return View(account);
        }
        [HttpPost]
        public ActionResult BringSocialMedia(TblSosyalMedya p)
        {
            var account = repo.Find(x => x.ID == p.ID);
            account.Ad = p.Ad;
            account.Link = p.Link;
            account.İkon = p.İkon;
            repo.TUpdate(account);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSocialMedia(int id)
        {
            var account=repo.Find(x=>x.ID == id);
            //if (account.Status == null)
            //{
            //    account.Status == true;
            //}
            account.Status = false;
            repo.TUpdate(account);
            return RedirectToAction("Index");
        }
    }
}