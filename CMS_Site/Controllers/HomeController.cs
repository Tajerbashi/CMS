using DAL;
using DAL.Repository;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS_Site.Controllers
{
    public class HomeController : Controller
    {
        DBContextsModels DB=new DBContextsModels();
        IPageRepository PageRepository;

        public HomeController()
        {
            PageRepository=new PageRepository(DB);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult ShowSlider()
        {
            return PartialView(PageRepository.PagesInSlider());
        }
    }
}