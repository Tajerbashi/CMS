using Pro_1_MVC_Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pro_1_MVC_Learning.Controllers
{
    public class ValidationNextController : Controller
    {
        DB_Class DB = new DB_Class();

        // GET: ValidationNext
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                DB.Cars.Add(car);
                DB.SaveChanges();
                return RedirectToRoute("ValidationNext");
            }
            return RedirectToRoute("Home");
        }
        public JsonResult CheckName(string name)
        {
            if (DB.Cars.Where( c => c.Name==name).FirstOrDefault() != null)
            {
                return Json(false,JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}