using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactRepository repo=new ContactRepository();
        public ActionResult Index()
        {
            var contact = repo.List();
            return View(contact);
        }
    }
}