using Pro_1_MVC_Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pro_1_MVC_Learning.Controllers
{
    public class ModelBindingController : Controller
    {
        DB_Class DB=new DB_Class();
        // GET:  
        public ActionResult Index()
        {
            return View();
        }

        // POST ModelSubmit
        [HttpPost]
        public ActionResult Submit([Bind(Exclude ="Counter")]News newss)
        {
            News news= new News();

            //  This method is in querystring and Default Url Config
            //news.Title = Request.QueryString["Title"];
            //news.Info = Request.QueryString["Info"];
            //news.Counter = Request.QueryString["Counter"];

            //  This method is Url Config Customize
            //news.Title = Request["Title"];
            //news.Info = Request["Info"];
            //news.Counter = Request["Counter"];

            //  This is Form Getting data
            //news.Title = Request.Form["Title"];
            //news.Info = Request.Form["Info"];
            //news.Counter = Request.Form["Counter"];

            //  This is Used For Exclude Binding in Method Action
            //[Bind(Exclude = "Counter")]News newss
            news.Title = newss.Title;
            news.Info = newss.Info;
            news.Counter = newss.Counter;

            //  This is Used For Include Binding in Method Action
            //[Bind(Include = "Title,Info")]News newss
            //news.Title = newss.Title;
            //news.Info = newss.Info;
            //news.Counter = newss.Counter;

            DB.News.Add(news);
            DB.SaveChanges();
            return Redirect("ModelIndex");
        }
    }
}