using Microsoft.AspNetCore.Mvc;
using Lab8.Models;

namespace Lab8.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            List<Book> books = new List<Book>
            {
                new Book
                {
                    Id = 1, Name = "1984", Author = "George Orwell", Price = 43,
                    PublishDate = new DateTime(2023, 11, 04)
                },
                new Book
                {
                    Id = 2, Name = "Looking for Alaska", Author = "John Green", Price = 50,
                    PublishDate = new DateTime(2005, 03, 03)
                },
                new Book
                {
                    Id = 3, Name = "More Than a Carpenter", Author = "Josh McDowell", Price = 80,
                    PublishDate = new DateTime(2024, 06, 12)
                }
            };

            return View(books);
        }
    }
}