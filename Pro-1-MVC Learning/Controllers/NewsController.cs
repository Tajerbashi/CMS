using Pro_1_MVC_Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pro_1_MVC_Learning.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        DB_Class DB = new DB_Class();

        public ActionResult Index()
        {
            return View(DB.News.ToList());
        }
        //  GET: News/CreateNews
        public ActionResult CreateNews()
        {
            return View(new News());
        }
        
        [HttpPost]
        public ActionResult SubmitNews(News news)
        {
            if (news.Id > 0)
            {
                News news1= DB.News.Find(news.Id);
                news1.Title = news.Title;
                news1.Info = news.Info;
                //news1.Picture = news.Picture;
                //news1.Like=news.Like;
                //news1.CommentInfo = news.CommentInfo;
                //news1.CommentCount =news.CommentCount;
                //news1.IsActive =news.IsActive;
            }
            else
            {
                DB.News.Add(news);
            }
            DB.SaveChanges();
            return Redirect(Url.RouteUrl("NewsIndex"));
        }
        public ActionResult Update(int id)
        {
            News news1 = DB.News.Find(id);
            return View("CreateNews",news1);
        }
        public ActionResult Delete(int id)
        {
            DB.News.Remove(DB.News.Find(id));
            DB.SaveChanges();
            return Redirect(Url.RouteUrl("NewsIndex"));
        }
    }
}