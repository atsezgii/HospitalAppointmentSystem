using Serilog.Context;

namespace WebAPI.Serilog
{
    public class UserNameLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public UserNameLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var userName = context.User.Identity.IsAuthenticated ? context.User.Identity.Name : "Anonymous";

            if (userName != null)
            {
                LogContext.PushProperty("UserName", userName);
            }

            await _next(context);
        }
    }

}
