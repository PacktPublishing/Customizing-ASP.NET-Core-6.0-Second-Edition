namespace RoutingSample
{
    public class MyHealthChecksMiddleware
    {
        private readonly ILogger<MyHealthChecksMiddleware> _logger;

        public MyHealthChecksMiddleware(
            RequestDelegate next,
            ILogger<MyHealthChecksMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            // add some checks here... 
            context.Response.StatusCode = 200;
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync("OK");
        }
    }
}