using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pro_1_MVC_Learning.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            var fileFolder = Server.MapPath("~/Files");
            var fileContent = System.IO.File.ReadAllText(System.IO.Path.Combine(fileFolder,"FileTest1.txt"));
            return View(model : fileContent);
        }
    }
}