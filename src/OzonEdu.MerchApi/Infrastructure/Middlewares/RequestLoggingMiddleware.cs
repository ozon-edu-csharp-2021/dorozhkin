using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace OzonEdu.MerchApi.Infrastructure.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await LogRequest(context);
            await _next(context);
        }

        private async Task LogRequest(HttpContext context)
        {
            try
            {
                if (context.Request.ContentLength > 0)
                {
                    var route = context.Request.Path;
                    var headers = context.Request.Headers;
                    var headersAsText = "";
                    
                    _logger.LogInformation("Request logged");
                    _logger.LogInformation("Headers", headers);

                    foreach (var header in headers)
                    {
                        headersAsText += $"{header.Value} \n";
                        _logger.LogInformation(header.Value);
                    }
                    
                    _logger.LogInformation(route);
                    // _logger.LogInformation(headersAsText);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log request body");
            }
        }
    }
}