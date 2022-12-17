using DAL;
using DAL.Models;
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
        private IPageComment pageComment;
        public NewsController()
        {
            pageGroupRepository = new PageGroupRepository(db);
            pageRepository = new PageRepository(db);
            pageComment = new PageCommentRepository(db);
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
        [Route("News/{id}")]
        public ActionResult ShowNewsInfo(int id)
        {
            var news = pageRepository.GetPageId(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            news.Visit += 1;
            pageRepository.UpdatePage(news);
            pageRepository.Save();
            return View(news);
        }

        public ActionResult AddComment(int id, String name,string email, string comment)
        {
            PageComment comment1= new PageComment();
            comment1.PageId = id;
            comment1.Name = name;
            comment1.Email= email;
            comment1.Comment = comment;
            comment1.CreateDate= DateTime.Now;
            pageComment.AddComment(comment1);
            return PartialView("ShowComments",pageComment.GetCommentByNewsId(id));
        }

        public ActionResult ShowComments(int id)
        {
            return PartialView(pageComment.GetCommentByNewsId(id));
        }
    }
}