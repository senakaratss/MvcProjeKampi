using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminAboutController : Controller
    {
        // GET: AdminAbout
        AboutManager abm = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutValues = abm.GetListBL();
            return View(aboutValues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            abm.AboutAddBL(p);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
        public ActionResult PassiveAbout(int id)
        {
            var aboutValue = abm.GetByIDBL(id);
            aboutValue.AboutStatus = false;
            abm.AboutUpdateBL(aboutValue);
            return RedirectToAction("Index");
        }
        public ActionResult ActiveAbout(int id)
        {
            var aboutValue = abm.GetByIDBL(id);
            aboutValue.AboutStatus = true;
            abm.AboutUpdateBL(aboutValue);
            return RedirectToAction("Index");
        }
    }
}