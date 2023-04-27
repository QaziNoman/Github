using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

using System.Threading.Tasks;

namespace BrandHub.Utilities
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext, IConfiguration configuration)
        {
            var path = httpContext.Request.Path;
            if (path.Value != "/" && path.Value != "/Login/Index")
            {
                if (httpContext.Session.GetString("LoginSession") == null)
                {
                    httpContext.Response.Redirect("/");
                }
            }
            if (string.IsNullOrEmpty(configuration["AppUrl:AppBaseUrl"]))
            {
                configuration["AppUrl:AppBaseUrl"] = httpContext.Request.Host.ToString();
            }
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}
