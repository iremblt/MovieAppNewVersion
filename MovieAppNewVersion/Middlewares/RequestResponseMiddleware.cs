using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Middleware
{
    public class RequestResponseMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestResponseMiddleware> _logger;
        public RequestResponseMiddleware(RequestDelegate next, ILogger<RequestResponseMiddleware> logger)
        { 
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext) 
        {
            await ReadRequest(httpContext);
            await _next(httpContext);
        }

        private async Task ReadRequest(HttpContext httpContext)
        {
            var requestBody = "";
            var req = httpContext.Request;
            httpContext.Request.EnableBuffering();

            using (StreamReader stream = new StreamReader(req.Body, Encoding.UTF8, true, 1024, true))
            {
                requestBody = await stream.ReadToEndAsync();
                req.Body.Position = 0;
            }
            _logger.LogInformation($"Request: {requestBody}");

        }

    }
}
