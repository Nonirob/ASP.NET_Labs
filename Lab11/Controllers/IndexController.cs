using Lab11.Filters;
using Lab11.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab11.Controllers
{
    [ServiceFilter(typeof(LoggerFilter))]
    [ServiceFilter(typeof(UserFilter))]
    public class IndexController : Controller
    {
        private readonly string _loggingFilePath;

        public IndexController()
        {
            _loggingFilePath = Path.Combine(Directory.GetCurrentDirectory(), "logs.txt");
        }

        public IActionResult Index()
        {
            ViewBag.UniqueUsersCount = CountUniqueUsers();

            ViewBag.LogEntries = ReadLogs();

            return View();
        }

        private int CountUniqueUsers()
        {
            var uniqueUsers = new HashSet<string>();

            try
            {
                var lines = System.IO.File.ReadAllLines(_loggingFilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 2)
                    {
                        var methodName = parts[1].Replace("'", "").Trim();
                        uniqueUsers.Add(methodName);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return uniqueUsers.Count;
        }

        private List<Logging> ReadLogs()
        {
            var logs = new List<Logging>();

            try
            {
                var lines = System.IO.File.ReadAllLines(_loggingFilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 2)
                    {
                        var log = new Logging
                        {
                            Datetime = DateTime.Parse(parts[0]),
                            Method = parts[1]
                        };
                        logs.Add(log);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return logs;
        }
    }
}