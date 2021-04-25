using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Shyjus.BrowserDetection;
using System.Threading.Tasks;

namespace Zad6_NET.Models
{
    public class BrowserDetectionMiddleware
    {
        private RequestDelegate _next;
        public BrowserDetectionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IBrowserDetector detector)
        {
            var browser = detector.Browser;

            if (browser.Name == BrowserNames.Edge || browser.Name == BrowserNames.EdgeChromium || browser.Name == BrowserNames.InternetExplorer)
            {
                await httpContext.Response.WriteAsync("Przegladarka nie jest obslugiwana");
            }
            else
            {
                await _next.Invoke(httpContext);
            }

        }
    }
    public static class UrlTransformerMiddlewareExtensions
    {
        public static IApplicationBuilder UseBrowserDetectionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BrowserDetectionMiddleware>();
        }
    }
}
