using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string APIKEYNAME = "X-API-KEY";
        private readonly ILogger<ApiKeyMiddleware> _logger;
        private readonly IConfiguration _configuration;

        private static readonly Action<ILogger, Exception?> _logApiKeyNotProvided =
            LoggerMessage.Define(LogLevel.Warning, new EventId(1, nameof(ApiKeyMiddleware)), "API Key was not provided.");
        private static readonly Action<ILogger, Exception?> _logUnauthorizedClient =
            LoggerMessage.Define(LogLevel.Warning, new EventId(2, nameof(ApiKeyMiddleware)), "Unauthorized client.");
        private static readonly Action<ILogger, string?, string, Exception?> _logForbiddenAction =
            LoggerMessage.Define<string?, string>(LogLevel.Warning, new EventId(3, nameof(ApiKeyMiddleware)), "Forbidden action. Action: {ActionName}, Role: {Role}");

        public ApiKeyMiddleware(RequestDelegate next, ILogger<ApiKeyMiddleware> logger, IConfiguration configuration)
        {
            _next = next;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey) || string.IsNullOrWhiteSpace(extractedApiKey))
            {
                _logApiKeyNotProvided(_logger, null);
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key was not provided.");
                return;
            }

            var apiKeys = _configuration.GetSection("ApiKeys").Get<Dictionary<string, string>>() ?? new Dictionary<string, string>();
            var roles = _configuration.GetSection("Roles").Get<Dictionary<string, List<string>>>() ?? new Dictionary<string, List<string>>();

            if (!apiKeys.TryGetValue(extractedApiKey!, out var role))
            {
                _logUnauthorizedClient(_logger, null);
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized client.");
                return;
            }

            var endpoint = context.GetEndpoint();
            var actionName = endpoint?.Metadata.GetMetadata<Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor>()?.ActionName;

            if (actionName == null || !roles.TryGetValue(role, out var allowedActions) || allowedActions == null || !allowedActions.Contains(actionName))
            {
                _logForbiddenAction(_logger, actionName ?? "Unknown", role, null);
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Forbidden action.");
                return;
            }

            await _next(context);
        }
    }
}
