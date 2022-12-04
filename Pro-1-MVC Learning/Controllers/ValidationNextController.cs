using Pro_1_MVC_Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.Mvc;

namespace Pro_1_MVC_Learning.Controllers
{
    public class ValidationNextController : Controller
    {
        DB_Class DB = new DB_Class();

        // GET: ValidationNext
        public ActionResult Index(string viewName)
        {
            if (viewName=="/")
            {
                return View();
            }
            else
            {
                return View("Teacher");
            }
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
            if (DB.Cars.Where(c => c.Name == name).FirstOrDefault() != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult CreateTeacher(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                DB.Teachers.Add(teacher);
                DB.SaveChanges();
                return RedirectToRoute("ValidationNext/");
            }
            return RedirectToRoute("Home");
        }
        public JsonResult CheckUser(string name)
        {
            if (DB.Teachers.Where(c => c.UserName == name).FirstOrDefault() != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}