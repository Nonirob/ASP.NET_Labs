using Microsoft.AspNetCore.Mvc.Filters;

namespace Lab11.Filters
{
    public class LoggerFilter : IActionFilter
    {
        private readonly string _loggingFilePath;

        public LoggerFilter(string logFilePath)
        {
            _loggingFilePath = logFilePath;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            
            var logMessage = $"{DateTime.Now} - '{actionName}' begin";
            File.AppendAllText(_loggingFilePath, logMessage + Environment.NewLine);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            
            var logMessage = $"{DateTime.Now} - '{actionName}' finished";
            File.AppendAllText(_loggingFilePath, logMessage + Environment.NewLine);
        }
    }
}