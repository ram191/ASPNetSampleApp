using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Collections.Generic;
using System;

namespace web_test_api
{
    public class MyLogger
    {
        private readonly RequestDelegate _next;

        public MyLogger(RequestDelegate next)
        {
            _next = next;
        }

        string path = @"/Users/training/Projects/ASPDemoRef/WebApiIntroAssignment/logs.txt";

        public async Task Invoke(HttpContext httpContext)
        {
            var messageList = new List<string>();
            string method = httpContext.Request.Method.ToString();
            string reqDate = DateTime.Now.ToString();
            string host = httpContext.Request.Host.ToString();
            string pathbase = httpContext.Request.Path.ToString();
            var reqMessage = $"[{reqDate}] Started {method} {pathbase} for {host}";
            
            if(httpContext.Request.Host.ToString() == "localhost:5000")
            {   
                messageList.Add(reqMessage);
                httpContext.Response.StatusCode = 403;
                string statusCode = httpContext.Response.StatusCode.ToString();
                DateTime newResDate = DateTime.Now;
                var resMessage = $"[{newResDate}] Completed {statusCode} {pathbase} for {pathbase} not allowed for {host}";
                messageList.Add(resMessage);
            }
            else
            {
                System.Console.WriteLine("It works");
                await _next(httpContext);
            }
            File.AppendAllLines(path, messageList);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyLogger>();
        }
    } 
}