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
    public class AuthorizationController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminDal());
        List<SelectListItem> roleValues = new List<SelectListItem>
            {
                new SelectListItem{Text="Admin",Value="A"},
                new SelectListItem{Text="Yazar",Value="B"},
                new SelectListItem{Text="Moderatör",Value="M"},
            };
        // GET: Authorization
        public ActionResult Index()
        {
            var values = adm.GetListBL();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
          
            ViewBag.roleValues = roleValues;
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            adm.AdminAddBL(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            ViewBag.roleValues = roleValues;
            var adminValue = adm.GetAdminByIdBL(id);
            return View(adminValue);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            adm.AdminUpdateBL(p);
            return RedirectToAction("Index");
        }

        
    }
}