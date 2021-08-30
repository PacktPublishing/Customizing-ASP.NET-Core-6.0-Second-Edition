namespace MiddlewaresSample
{
    public class AppStatusMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _status;


        public AppStatusMiddleware(
            RequestDelegate next, string status)
        {
            _next = next;
            _status = status;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync($"Hello {_status}!");
        }
    }

    public static class MapAppStatusMiddlewareExtension
    {
        public static IEndpointConventionBuilder
          MapAppStatus(
            this IEndpointRouteBuilder routes,
            string pattern = "/",
            string name = "World")
        {
            var pipeline = routes
                .CreateApplicationBuilder()
                .UseMiddleware<AppStatusMiddleware>(name)
                .Build();

            return routes.Map(pattern, pipeline)
                .WithDisplayName("AppStatusMiddleware");
        }
    }


}