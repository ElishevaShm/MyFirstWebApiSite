using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Service;
using System.Threading.Tasks;

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
            //httpContext.Response.HOST.ToString();
            
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
