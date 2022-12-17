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
    public class SearchController : Controller
    {
        private IPageRepository pageRepository;
        DBContextsModels DB=new DBContextsModels();
        public SearchController()
        {
            pageRepository = new PageRepository(DB);
        }
        // GET: Search
        public ActionResult Index(string search)
        {
            ViewBag.search=search;
            return View(pageRepository.SearchPage(search));
        }
    }
}