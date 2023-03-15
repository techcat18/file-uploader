using System;
using System.Threading.Tasks;
using FileUploader.API.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FileUploader.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(
            RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = exception switch
            {
                FileUploadFailedException => StatusCodes.Status500InternalServerError,
                _ => StatusCodes.Status500InternalServerError
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;
            
            return context.Response.WriteAsync(JsonConvert.SerializeObject(new {error = exception.Message}));
        }
    }
}