using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Lab7.Controllers
{
    public class FileController : Controller
    {
        [HttpGet]
        public IActionResult GetFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetFile(string firstName, string surname, string fileName)
        {
            string content = $"Hi, {firstName} {surname}!!!";
            
            byte[] byteArray = Encoding.UTF8.GetBytes(content);
            return File(byteArray, "text/plain", $"{fileName}.txt");
        }
    }
}