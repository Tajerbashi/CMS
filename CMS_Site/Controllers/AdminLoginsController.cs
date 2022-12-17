using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Repository;
using DAL.Services;
using System.Web.Security;
namespace CMS_Site.Controllers
{
    public class AdminLoginsController : Controller
    {
        private DBContextsModels DB = new DBContextsModels();
        private IAdminLoginRepository adminLogin;

        public AdminLoginsController()
        {
            adminLogin = new AdminLoginRepository(DB);
        }
        // GET: AdminLogins
        public ActionResult Index()
        {
            return View(adminLogin.GetAllAdmin());
        }

        // GET: AdminLogins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogin admin = adminLogin.GetAdminById(id.Value);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // GET: AdminLogins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminLogins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoginId,Username,Email,Password")] AdminLogin admin)
        {
            if (ModelState.IsValid)
            {
                adminLogin.CreateAdmin(admin);
                adminLogin.Save();
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        // GET: AdminLogins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogin admin = adminLogin.GetAdminById(id.Value);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: AdminLogins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoginId,Username,Email,Password")] AdminLogin admin)
        {
            if (ModelState.IsValid)
            {
                adminLogin.CreateAdmin(admin);
                adminLogin.Save();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        // GET: AdminLogins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogin admin = adminLogin.GetAdminById(id.Value);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: AdminLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminLogin admin = adminLogin.GetAdminById(id);
            adminLogin.DeleteAdmin(admin);
            adminLogin.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DB.Dispose();
            }
            base.Dispose(disposing);
        }
        // AdminLogins/LoginPage
        public ActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginPage(LoginViewModel login, string ReturnUrl = "/")
        {
            if (ModelState.IsValid)
            {
                AdminLogin admin = new AdminLogin() { Username = login.Username, Password = login.Password };
                if (adminLogin.IsAdmin(admin))
                {
                    FormsAuthentication.SetAuthCookie(login.Username,login.IsRemember);
                    return Redirect(ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("Username", "Username is Invalid");
                }
            }
            return View(login);
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}
