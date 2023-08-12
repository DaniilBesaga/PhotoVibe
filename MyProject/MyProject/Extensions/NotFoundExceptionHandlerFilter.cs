using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyProject.Extensions
{
    public class NotFoundMiddleware
    {
        private readonly RequestDelegate _next;

        public NotFoundMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            if (endpoint != null)
            {
                await _next.Invoke(context);
                return;
            }

            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("<h2>Page doesnt exist</h2>");
            // или использовать своё собственное представление:
            // await context.Response.WriteAsync(await RenderViewToStringAsync("NotFound"));
        }
    }

    public static class NotFoundMiddlewareExtensions
    {
        public static IApplicationBuilder UseNotFoundMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<NotFoundMiddleware>();
        }
    }
}