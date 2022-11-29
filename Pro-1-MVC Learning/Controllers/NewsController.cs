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
        public ActionResult Index()
        {
            return View();
        }

        List<News> newses = new List<News> {
                new News{Id=1,Title="Kaihan",Info="This is a test news Kaihan"},
                new News{Id=2,Title="Tajer",Info="This is a test news Tajer"},
                new News{Id=3,Title="Mahdi",Info="This is a test news Mahdi"},
                new News{Id=4,Title="Rashid",Info="This is a test news Rashid"},
                new News{Id=5,Title="Javad",Info="This is a test news Javad"},
                new News{Id=6,Title="Mohammad",Info="This is a test news Mohammad"},
                new News{Id=7,Title="Reza",Info="This is a test news Reza"},
            };
        public ActionResult NewsInfo(int id,string admin)
        {
            var news=newses.FirstOrDefault(c => c.Id==id);
            return View(news);
        }
    }
}