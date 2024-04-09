using Microsoft.AspNetCore.Mvc;
using Lab10.Models;

namespace Lab10.Controllers
{
    public class FormController : Controller
    {
        private static List<ConsultationForm> _consultations = new List<ConsultationForm>();

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]    
        public IActionResult Index(ConsultationForm model)
        {
            if (ModelState.IsValid)
            {
                _consultations.Add(model);
                int lastIndex = _consultations.Count - 1;
                return RedirectToAction("Confirmation", new { id = lastIndex });
            }

            return View(model);
        }
        public IActionResult Confirmation(int id)
        {
            var model = _consultations[id];
            return View(model);
        }
    }
}