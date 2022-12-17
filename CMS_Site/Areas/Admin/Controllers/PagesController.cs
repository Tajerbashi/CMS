using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Repository;
using DAL.Services;

namespace CMS_Site.Areas.Admin.Controllers
{
    [Authorize]
    public class PagesController : Controller
    {
        private DBContextsModels db = new DBContextsModels();

        private IPageRepository pageRepository;
        private IPageGroupRepository pageGroupRepository;


        public PagesController()
        {
            pageRepository= new PageRepository(db);
            pageGroupRepository=new PageGroupRepository(db);
        }
        // GET: Admin/Pages
        public ActionResult Index()
        {
            return View(pageRepository.GetAllPage());
        }

        // GET: Admin/Pages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = pageRepository.GetPageId(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // GET: Admin/Pages/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(pageGroupRepository.GetAllGroup(), "GroupId", "GroupTitle");
            return View();
        }

        // POST: Admin/Pages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageId,GroupID,Title,Description,Text,Visit,Tags,Photo,ShowSlider,CreateTime")] Page page, HttpPostedFileBase photoUp )
        {
            if (ModelState.IsValid)
            {
                page.Visit = 0;
                page.CreateTime = DateTime.Now;
                if (photoUp != null)
                {
                    page.Photo=Guid.NewGuid()+Path.GetExtension(photoUp.FileName);
                    photoUp.SaveAs(Server.MapPath("/Image/"+page.Photo));
                }
                pageRepository.CreatePage(page);
                pageRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(pageGroupRepository.GetAllGroup(), "GroupId", "GroupTitle", page.GroupID);
            return View(page);
        }

        // GET: Admin/Pages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = pageRepository.GetPageId(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(pageGroupRepository.GetAllGroup(), "GroupId", "GroupTitle", page.GroupID);
            return View(page);
        }

        // POST: Admin/Pages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PageId,GroupID,Title,Description,Text,Visit,Photo,ShowSlider,CreateTime,Tags")] Page page, HttpPostedFileBase photoUp)
        {
            if (ModelState.IsValid)
            {
                if (photoUp != null)
                {
                    if (page.Photo != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/Image/" + page.Photo));
                    }
                    page.Photo=Guid.NewGuid()+Path.GetExtension(photoUp.FileName);
                    photoUp.SaveAs(Server.MapPath("/Image/"+page.Photo));
                }
                pageRepository.UpdatePage(page);
                pageRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(pageGroupRepository.GetAllGroup(), "GroupId", "GroupTitle", page.GroupID);
            return View(page);
        }

        // GET: Admin/Pages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = pageRepository.GetPageId(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: Admin/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Page page = pageRepository.GetPageId(id);
            if (page.Photo != null)
            {
                System.IO.File.Delete(Server.MapPath("/Image/" + page.Photo));
            }
            pageRepository.DeletePage(page);
            pageRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
