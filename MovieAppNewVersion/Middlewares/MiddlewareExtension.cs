using Microsoft.AspNetCore.Builder;

namespace MovieAppNewVersion.Middleware
{
    public static class MiddlewareExtension
    {
     public static IApplicationBuilder UseRequestResponse(this IApplicationBuilder builder)
     {
        return builder.UseMiddleware<RequestResponseMiddleware>();
     }
    }
}
