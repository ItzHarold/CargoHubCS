using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Filter
{
    public class GenericActionFilter : IActionFilter
    {
        private readonly ILogger<GenericActionFilter> _logger;
        private static readonly Action<ILogger, string, Exception?> _logExecutingAction;
        private static readonly Action<ILogger, string, Exception?> _logExecutedAction;

        static GenericActionFilter()
        {
            _logExecutingAction = LoggerMessage.Define<string>(
                LogLevel.Information,
                new EventId(1, nameof(OnActionExecuting)),
                "Executing action: {ActionName}");

            _logExecutedAction = LoggerMessage.Define<string>(
                LogLevel.Information,
                new EventId(2, nameof(OnActionExecuted)),
                "Executed action: {ActionName}");
        }

        public GenericActionFilter(ILogger<GenericActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logExecutingAction(_logger, context.ActionDescriptor.DisplayName ?? "Unknown action", null);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logExecutedAction(_logger, context.ActionDescriptor.DisplayName ?? "Unknown action", null);
        }
    }
}
