using Lab9.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab9.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Weather(string region)
        {
            return ViewComponent("Weather", region);
        }
        
        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Macbook pro 14 m3max", Price = 9999999.99 },
                new Product { Id = 2, Name = "Money$ printer", Price = 999.99 },
            };

            return View(products);
        }
    }
}