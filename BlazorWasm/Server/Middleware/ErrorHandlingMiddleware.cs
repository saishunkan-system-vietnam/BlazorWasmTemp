using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BlazorWasm.Server.Middleware
{
	public class ErrorHandlingMiddleware
	{
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            if (next == null) throw new ArgumentNullException(nameof(next));
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext /* other dependencies */)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            Log.Logger.Error(ex, context.Request.Method);

            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            return context.Response.WriteAsync(result);
        }
    }
}
