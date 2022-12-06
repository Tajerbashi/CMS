using System.IO;
using System.Web;
using System.Web.Mvc;
namespace Pro_1_MVC_Learning.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Read()
        {
            var fileFolder = Server.MapPath("~/Files");
            var fileContent = System.IO.File.ReadAllText(System.IO.Path.Combine(fileFolder, "FileTest1.txt"));
            return View("Index",model : fileContent);
        }

        public ActionResult Download()
        {
            //FileContentResult
            //FilePathResult
            //FileStreamResult
            //return new FileContentResult(System.IO.File.ReadAllBytes(""));
            var fileFolder = Server.MapPath("~/Files");
            var fileContent = System.IO.Path.Combine(fileFolder, "FileTest1.txt");
            //return new FileContentResult(System.IO.File.ReadAllBytes(fileContent),System.Net.Mime.MediaTypeNames.Text.Plain);
            //return new FileContentResult(System.IO.File.ReadAllBytes(fileContent),System.Net.Mime.MediaTypeNames.Application.Octet);
            //return File(System.IO.File.ReadAllBytes(fileContent),System.Net.Mime.MediaTypeNames.Application.Octet,"FileName.txt");
            return File(fileContent,System.Net.Mime.MediaTypeNames.Application.Octet,"FileName.txt");
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
            return View("Index");
        }
    }
}