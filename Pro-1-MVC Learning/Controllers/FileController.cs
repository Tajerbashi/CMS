using Pro_1_MVC_Learning.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;

namespace Pro_1_MVC_Learning.Controllers
{
    public class FileController : Controller
    {
        #region Code1
        // GET: File
        public ActionResult Index()
        {
            var rootFolder = Server.MapPath("~/Files");
            var files = System.IO.Directory.GetFiles(rootFolder).ToList();
            return View(files);
        }
        public ActionResult Read()
        {
            List<string> UploadedFiles = new List<string>();
            var fileFolder = Server.MapPath("~/Files");
            var fileContent = System.IO.File.ReadAllText(System.IO.Path.Combine(fileFolder, "FileTest1.txt"));
            UploadedFiles.Add(fileContent);
            return View("Index",UploadedFiles);
        }

        public ActionResult Download(string fileName)
        {
            //FileContentResult
            //FilePathResult
            //FileStreamResult

            //return new FileContentResult(System.IO.File.ReadAllBytes(""));

            var fileFolder = Server.MapPath("~/Files");
            var fileContent = System.IO.Path.Combine(fileFolder, fileName);
            if ( !System.IO.File.Exists(fileContent) )
            {
                return HttpNotFound();
            }
            //return new FileContentResult(System.IO.File.ReadAllBytes(fileContent),System.Net.Mime.MediaTypeNames.Text.Plain);
            //return new FileContentResult(System.IO.File.ReadAllBytes(fileContent),System.Net.Mime.MediaTypeNames.Application.Octet);
            //return File(System.IO.File.ReadAllBytes(fileContent),System.Net.Mime.MediaTypeNames.Application.Octet,"FileName.txt");
            return File(fileContent, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            //return null;
        }
        
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            // Size is important goto Web.config in System.Web > httpRuntime > maxRequestLenght="100000000"
            // File will saved in File Folder in next line
            var filesFolder = Server.MapPath("~/Files");
            var filePath = System.IO.Path.Combine(filesFolder,file.FileName);
            file.SaveAs(filePath);
            ViewBag.Message = "File Uploaded Successfully";
            return RedirectToAction("Index");
        }
        #endregion
        
        
        
        //          Database
        DB_Class DB =new DB_Class();
        public ActionResult IndexDB()
        {
            
            return View(DB.Files.OrderBy(i => i.FileName).ToList());
        }
        [HttpPost]
        public ActionResult UploadDB(HttpPostedFileBase file)
        {
            var fileBytes = new byte[file.InputStream.Length];
            file.InputStream.Read(fileBytes, 0, fileBytes.Length);
            var fileHash=Convert.ToBase64String(MD5.Create().ComputeHash(fileBytes));

            if (DB.Files.Any(c => c.FileHash == fileHash))
            {
                ViewBag.Message = "File already uploaded ...";
                return RedirectToAction("IndexDB", DB.Files.OrderBy(i => i.FileName).ToList());
            }
            var fileId = Guid.NewGuid();
            var filePath=System.IO.Path.Combine(Server.MapPath("~/Files"),fileId.ToString());
            file.SaveAs(filePath);
            Files newFile = new Files();
            newFile.Id = fileId;
            newFile.FileName = file.FileName;
            newFile.ContentType=file.ContentType;
            newFile.FileHash= fileHash;
            newFile.FielLength = file.ContentLength.ToString();
            newFile.UploadData = DateTime.Now;
            DB.Files.Add(newFile);
            DB.SaveChanges();
            Session["Message"] = "File Successfully Uploaded ...!";
            return RedirectToRoute("IndexDB", DB.Files.OrderBy(i => i.FileName).ToList());
        }
        public ActionResult DownloadDB(Guid Id)
        {
            var filePath = System.IO.Path.Combine(Server.MapPath("~/Files"), Id.ToString());
            var uploadedFiles = DB.Files.Find(Id);
            if (! System.IO.File.Exists(filePath) || uploadedFiles == null)
            {
                return HttpNotFound();
            }
            return File(filePath,uploadedFiles.ContentType,uploadedFiles.FileName);
        }
        public ActionResult DeleteDB(Guid Id)
        {
            var filePath = System.IO.Path.Combine(Server.MapPath("~/Files"), Id.ToString());
            var uploadedFiles = DB.Files.Find(Id);
            if (!System.IO.File.Exists(filePath) || uploadedFiles == null)
            {
                return HttpNotFound();
            }
            System.IO.File.Delete(filePath);
            DB.Files.Remove(uploadedFiles);
            DB.SaveChanges();
            Session["Message"] = "File Deleted";
            return RedirectToRoute("IndexDB", DB.Files.OrderBy(i => i.FileName).ToList());
        }
    }
}