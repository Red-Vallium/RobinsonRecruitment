using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Robinson.Middleware
{
    public class HttpLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private Stopwatch _stopWatch { get; set; }
        private ILogger<HttpLoggerMiddleware> _logger;

        public HttpLoggerMiddleware(RequestDelegate next, ILogger<HttpLoggerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            _stopWatch = Stopwatch.StartNew();

            _logger.LogInformation(context.Request.Path.ToString() + "\n"
                + context.Request.Method + "\n"
                + context.Request.ContentType + "\n"
                + context.Request.HttpContext.Connection.RemoteIpAddress.ToString());
               

            await _next(context);

            var elapsedMs = _stopWatch.ElapsedMilliseconds.ToString();

            _logger.LogInformation(context.Response.StatusCode.ToString() + "\n"
               + $"Time elapsed {elapsedMs} ms");
 
        }
    }
}

