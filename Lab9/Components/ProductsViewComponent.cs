using Lab9.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab9.Components
{
    public class ProductsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<Product> products)
        {
            return View(products);
        }
    }
}