using Pro_1_MVC_Learning.Models.Function_Codes;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.WebPages;

namespace Pro_1_MVC_Learning.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index(string word)
        {
            if (word.IsEmpty())
            {
                word = "Kaihan";
            }
            return View(model : MachineKeys.KeyEncode(word,"MyKey"));
        }
    }
}