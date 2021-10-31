using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace OzonEdu.MerchApi.Infrastructure.Middlewares
{
    public class ResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ResponseLoggingMiddleware> _logger;

        public ResponseLoggingMiddleware(RequestDelegate next, ILogger<ResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
            await LogResponseAsync(context);
        }

        private async Task LogResponseAsync(HttpContext context)
        {
            try
            {
                var headers = context.Response.Headers;
                var route = context.Request.Path;
                
                if (headers["Content-Type"] == "application/grpc")
                    return;
                
                var headersStringBuilder = new StringBuilder();
                
                _logger.LogInformation("Response logged");
                
                foreach (var header in headers) 
                    headersStringBuilder.Append($"{header.Key} : {header.Value}\n");

                var headersAsText = headersStringBuilder.ToString();
                
                _logger.LogInformation($"Headers:\n{headersAsText}");
                _logger.LogInformation($"Request route:\n{route}");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log response");
            }
        }
    }
}