using Pro_1_MVC_Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pro_1_MVC_Learning.Controllers
{
    public class ValidationController : Controller
    {
        DB_Class DB = new DB_Class();
        // GET: Validation
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RegisterForm()
        {
            return View(new Person());
        }
        [HttpPost]
        public ActionResult Create(Person person)
        {
            DB.People.Add(person);
            DB.SaveChanges();
            return RedirectToRoute("ValidationRegisterForm");
        }
        public ActionResult ShowData()
        {
            return View(DB.People.ToList());
        }
    }
}