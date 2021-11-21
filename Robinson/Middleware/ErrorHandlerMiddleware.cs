using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Robinson.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Robinson.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ApiException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";

                var jsonToSend = JsonSerializer.Serialize(new { Errors = new List<string>() { ex.UserMessagge } });
                await context.Response.WriteAsync(jsonToSend);
            }
            catch (Exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var jsonToSend = JsonSerializer.Serialize(new { Errors = new List<string>() { "Unexpected error occurred, try again later" } });
                await context.Response.WriteAsync(jsonToSend);
            }
        }
    }
}
