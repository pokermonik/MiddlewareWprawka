using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace MiddlewareWprawka
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class BrowserNameMiddleware
    {
        private readonly RequestDelegate _next;

        public BrowserNameMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            String BrowserName=httpContext.Request.Headers["User-Agent"].ToString();
            if(BrowserName.Contains("Chrome"))
            {
                httpContext.Response.Redirect("https://www.mozilla.org/pl/firefox/new/");
            }
         
            return _next(httpContext);
            
            
        
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BrowserNameMiddleware>();
        }
    }
}
