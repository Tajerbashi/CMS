using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pro_1_MVC_Learning.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Products()
        {
            return View();
        }
        public ActionResult News()
        {
            return View();
        }
    }
}