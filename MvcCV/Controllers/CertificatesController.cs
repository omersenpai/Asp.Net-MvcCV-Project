using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class CertificatesController : Controller
    {
        // GET: Certificates
        CertificatesRepository repo=new CertificatesRepository();
        public ActionResult Index()
        {
            var certificate = repo.List();
            return View(certificate);
        }
        [HttpGet]
        public ActionResult AddCertificate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCertificate(TblSertifikalarim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult BringCertificate(int id)
        {
            var certificate = repo.Find(x => x.ID == id);
            return View(certificate);
        }
        [HttpPost]
        public ActionResult BringCertificate(TblSertifikalarim t)
        {
            var certificate = repo.Find(x => x.ID == t.ID);
            certificate.Tarih = t.Tarih;
            certificate.Aciklama = t.Aciklama;
            repo.TUpdate(certificate);
            return RedirectToAction("Index");

        }
        public ActionResult DeleteCertificate(int id)
        {
            var certificate = repo.Find(x => x.ID == id);
            repo.TDelete(certificate);
            return RedirectToAction("Index");
        }
    }
}