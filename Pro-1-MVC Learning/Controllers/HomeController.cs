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
        // GET: News
        public ActionResult News()
        {
            return View();
        }
        // GET: Blog
        public ActionResult Blog()
        {
            return View();
        }
        // GET: About
        public ActionResult About()
        {
            return View();
        }
        // GET: Panel
        public ActionResult Panel()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        // GET: Index1
        [OutputCache(Duration = 5)]
        public ActionResult Index1()
        {
            return View();
        }
    }
}