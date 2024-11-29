using MvcCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCV.Controllers
{
    [AllowAnonymous]//Global authorize attribute dışında kalması için
    public class LoginController : Controller
    {
      
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin p)
        {
            DbCvEntities db=new DbCvEntities();
            var userInfo = db.TblAdmins.FirstOrDefault(x => x.KullaniciAdi == p.KullaniciAdi && x.Sifre == p.Sifre);
            if (userInfo != null) {
                FormsAuthentication.SetAuthCookie(userInfo.KullaniciAdi, false);
                Session["KullaniciAdi"]=userInfo.KullaniciAdi.ToString();
                return RedirectToAction("Index","Experience");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}