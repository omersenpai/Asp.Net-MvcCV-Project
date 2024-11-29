using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;

namespace MvcCV.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        

        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var degerler = db.TblHakkimdas.ToList();
            return View(degerler);
        }
        public PartialViewResult SocialMedia()
        {
            var socialMedia = db.TblSosyalMedyas.ToList();
            return PartialView(socialMedia);
        }
        public PartialViewResult Experience()
        {
            var experience = db.TblDeneyimlerims.ToList();
            return PartialView(experience);
        }
        public PartialViewResult Education()
        {
            var education = db.TblEgitimlerims.ToList();
            return PartialView(education);
        }
        public PartialViewResult Interest()
        {
            var ınterest = db.TblHobilerims.ToList();
            return PartialView(ınterest);
        }
        public PartialViewResult Skills()
        {
            var skills = db.TblYeteneklerims.ToList();
            return PartialView(skills);
        }
        public PartialViewResult Awards()
        {
            var awards = db.TblSertifikalarims.ToList();
            return PartialView(awards);
        }
        [HttpGet] //mesaj gönderimden sonra boş kayıtı önlemek için.
        public PartialViewResult Contact()
        {

            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Contact(TblIletisim t)
        {
            db.TblIletisims.Add(t);
            t.Tarih=DateTime.Now;
            db.SaveChanges();
            return PartialView();
        }
    }
}