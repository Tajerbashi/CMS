using System.IO;
using System.Web.Mvc;
namespace Pro_1_MVC_Learning.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            var fileFolder = Server.MapPath("~/Files");
            var fileContent = System.IO.File.ReadAllText(System.IO.Path.Combine(fileFolder,"FileTest1.txt"));
            return View(model : fileContent);
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
    }
}