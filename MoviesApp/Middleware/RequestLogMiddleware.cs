using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MoviesApp.Middleware
{
    public class RequestLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestLogMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLogMiddleware>();

        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.Value.ToLower().Contains("actor"))
            {
                _logger.LogDebug($"Query: {string.Join(", ", from q in httpContext.Request.Query select $"{q.Key} = {String.Join(", ", q.Value)}")};\n" +
                                 $"Request: {httpContext.Request.Path}\n" +
                                 $"Method: {httpContext.Request.Method}");
            }
            await _next(httpContext);
        }
    }
}