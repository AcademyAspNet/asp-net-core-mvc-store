using Microsoft.AspNetCore.Mvc.Filters;

namespace Asp_Net_Core_Mvc_Store.Filters
{
    public class BenchmarkFilter : Attribute, IActionFilter
    {
        private readonly ILogger<BenchmarkFilter> _logger;

        private DateTime startedAt;

        public BenchmarkFilter(ILogger<BenchmarkFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            startedAt = DateTime.Now;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            DateTime finishedAt = DateTime.Now;
            TimeSpan duration = finishedAt - startedAt;

            _logger.LogInformation("Время обработки запроса: {0}", duration);
        }
    }
}
