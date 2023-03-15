using FileUploader.API.Middleware;
using Microsoft.AspNetCore.Builder;

namespace FileUploader.API.Extensions
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}