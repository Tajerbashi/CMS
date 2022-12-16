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
    public class NewsController : Controller
    {
        DBContextsModels db=new DBContextsModels();
        private IPageGroupRepository pageGroupRepository;
        private IPageRepository pageRepository;
        public NewsController()
        {
            pageGroupRepository = new PageGroupRepository(db);
            pageRepository = new PageRepository(db);
        }
        // GET: News
        [HttpGet]
        public ActionResult ShowGroups()
        {
            return PartialView(pageGroupRepository.getGroupForView());
        }
        public ActionResult ShowGroupsInNavbar()
        {
            return PartialView(pageGroupRepository.getGroupForView());
        }
        public ActionResult ShowTopNews()
        {
            return PartialView(pageRepository.TopNews());
        }
        public ActionResult LastNews()
        {
            return PartialView(pageRepository.LastNews());
        }
        [Route("Archive")]
        public ActionResult Archive()
        {
            return View(pageRepository.GetAllPage());
        }
        [Route("Group/{id}/{title}")]
        public ActionResult ShowNewsByGroupId(int id,string title)
        {
            ViewBag.name = title;
            return View(pageRepository.ShowPageByGroupId(id));
        }
    }
}