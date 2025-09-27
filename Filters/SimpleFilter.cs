using Microsoft.AspNetCore.Mvc.Filters;

namespace Asp_Net_Core_Mvc_Store.Filters
{
    public class SimpleFilter : Attribute, IActionFilter
    {
        private readonly ILogger<SimpleFilter> _logger;

        public SimpleFilter(ILogger<SimpleFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("Выполнился метод OnActionExecuting");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("Выполнился метод OnActionExecuted");
        }
    }
}
