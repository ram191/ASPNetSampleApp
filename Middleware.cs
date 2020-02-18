using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace web_test_api
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;

        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        string path = @"/Users/training/Projects/ASPDemoRef/WebApiIntroAssignment/logs.txt";

        public async Task Invoke(HttpContext httpContext)
        {
            if(httpContext.Request.Host.ToString() == "localhost:5000")
            {
                File.WriteAllText(path, "Test request");
                await httpContext.Response.WriteAsync("Not allowed");
                File.WriteAllText(path, "Test response");
            }
            else
            {
                System.Console.WriteLine("It works");
                await _next(httpContext);
            }
            
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware>();
        }
    } 
}