using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace VivaioInCloud.Common.Middleware
{
    public class CorrelationIdMiddleware : IMiddleware
    {
        public static string HEADER = "X-Correlation-ID";

        public CorrelationIdMiddleware() { }

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string correlationId = "";

            if (context.Request.Headers.TryGetValue(HEADER, out StringValues requestCorrelationId))
            {
                correlationId = requestCorrelationId;
            }
            else
            {
                correlationId = Guid.NewGuid().ToString();
                context.Request.Headers.Add(HEADER, correlationId);
            }

            // apply the correlation ID to the response header for client side tracking
            context.Response.OnStarting(() =>
            {
                context.Response.Headers.Add(HEADER, correlationId);
                return Task.CompletedTask;
            });

            return next(context);
        }
    }
}
