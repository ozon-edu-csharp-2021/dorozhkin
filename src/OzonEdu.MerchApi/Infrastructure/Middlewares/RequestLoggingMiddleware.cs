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
                var route = context.Request.Path;
                var headers = context.Request.Headers;
                
                if (headers["Content-Type"] == "application/grpc")
                    return;
                
                var headersAsText = "";

                _logger.LogInformation("Request logged");

                foreach (var header in headers) 
                    headersAsText += $"{header.Key} : {header.Value}\n";

                _logger.LogInformation($"Headers:\n{headersAsText}");
                _logger.LogInformation($"Route:\n{route}");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log request");
            }
        }
    }
}