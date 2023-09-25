using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MovieArchiveAPI.Services;

namespace MovieArchiveAPI.Middlewares
{
    public class MoviArchiveMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _logger = new ConsoleLogger();
        public MoviArchiveMiddleware(RequestDelegate next, ILoggerService logger){
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context){
            var watch = Stopwatch.StartNew();
            string message = "[Request] HTTP " + context.Request.Method + " - " + context.Request.Path;
            _logger.Write(message);

            await _next.Invoke(context);
            watch.Stop();
            message = "[Response] HTTP " + context.Request.Method + " - " + context.Request.Path 
                + " responded " + context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + " ms.";
            _logger.Write(message);
        }
    }

    public static class MiddlewareExtension{
        public static IApplicationBuilder UseMovieArchive(this IApplicationBuilder builder){
            return builder.UseMiddleware<MoviArchiveMiddleware>();
        }
    }
}