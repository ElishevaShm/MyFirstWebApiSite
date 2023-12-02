using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Service;
using Entity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.RenderTree;

namespace MyFirstWebApiSite.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ratingService _ratingService;

        public RatingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ratingService ratingService)
        {
            Rating rating = new()
            {
                Host = httpContext.Request.Host.Host,
                Method = httpContext.Request.Method,
                Path = httpContext.Request.Path,
                Referer = httpContext.Request.Headers["Referer"],
                UserAgent = httpContext.Request.Headers["UserAgent"],
                RecordDate = DateTime.Now
            };
            

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}
