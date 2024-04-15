using Microsoft.AspNetCore.Mvc.Filters;

namespace Lab11.Filters
{
    public class UserFilter : IActionFilter
    {
        private readonly string _loggingFilePath;
        private readonly HashSet<string> _uniqueUsers = new HashSet<string>();

        public UserFilter(string logFilePath)
        {
            _loggingFilePath = logFilePath;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var userId = context.HttpContext.User.Identity.Name;
            if (!string.IsNullOrEmpty(userId))
            {
                _uniqueUsers.Add(userId);
                
                var logMessage = $"Unique users: {_uniqueUsers.Count}";
                
                File.WriteAllText(_loggingFilePath, logMessage);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}