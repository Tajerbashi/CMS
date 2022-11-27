using Pro_1_MVC_Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pro_1_MVC_Learning.Controllers
{
    public class HomeController:Controller
    {
        public ActionResult Index()
        {
            // Index

            var person = new Person();
            person.Id = 1;
            person.Name = "Kaihan";
            person.LastName = "Tajerbashi";
            person.Age = 30;
            person.Phone = "09020320844";

            return View(person);
        }
        public ActionResult Index1()
        {
            // Index1
            return View();
        }
        public ActionResult Index2()
        {
            // _Layer1

            var person = new Person();
            person.Id = 1;
            person.Name = "Kaihan";
            person.LastName = "Tajerbashi";
            person.Age = 30;
            person.Phone = "09020320844";

            return View(person);
        }
        public ActionResult About2()
        {
            // _Layer1
            return View();
        }
    }
}