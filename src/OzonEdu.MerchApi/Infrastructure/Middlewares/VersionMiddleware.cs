using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OzonEdu.MerchApi.HttpModels;
using OzonEdu.MerchApi.Models;

namespace OzonEdu.MerchApi.Infrastructure.Middlewares
{
    public class VersionMiddleware
    {
        public VersionMiddleware(RequestDelegate next)
        {
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "no version";
            var serviceName = Assembly.GetExecutingAssembly().GetName().Name;
            await context.Response.WriteAsJsonAsync(new MerchApiVersionResponse(version,serviceName));
        }
    }
}