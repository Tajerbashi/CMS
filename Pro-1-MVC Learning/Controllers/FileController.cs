using System.Collections.Generic;
using System.IO;
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

    }
}