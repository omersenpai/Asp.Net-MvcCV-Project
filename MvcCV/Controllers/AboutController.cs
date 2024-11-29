using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class AboutController : Controller
    {

        DbCvEntities db = new DbCvEntities();
        AboutRepository repo = new AboutRepository();
        [HttpGet]
        public ActionResult Index()
        {
            var aboutMe = repo.List();
            return View(aboutMe);

        }
        [HttpPost]
        public ActionResult Index(TblHakkimda i)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Ad = i.Ad;
            t.Soyad = i.Soyad;
            t.Adres = i.Adres;
            t.Mail = i.Mail;
            t.Telefon = i.Telefon;
            t.Aciklama = i.Aciklama;
            t.Resim = i.Resim;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    } }