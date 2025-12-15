using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminContentController : Controller
    {
        // GET: AdminContent
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllContent(string p)
        {

            var values = cm.GetListBL(p);
            if (p ==null)
            {
                return View(cm.GetListBL(""));
            }
            return View(values);

        }
        public ActionResult ContentByHeading(int id)
        {
            var contentValues = cm.GetListByHeadingIdBL(id);
            return View(contentValues);
        }
    }
}