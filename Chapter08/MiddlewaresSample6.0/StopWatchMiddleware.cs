using System.Diagnostics;

namespace MiddlewaresSample
{
    public class StopwatchMiddleware
    {
        private readonly RequestDelegate _next;

        public StopwatchMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var s = new Stopwatch();
            s.Start();

            // execute the rest of the pipeline
            await _next(context);

            s.Stop(); //stop measuring
            var result = s.ElapsedMilliseconds;

            // write out the milliseconds needed
            await context.Response.WriteAsync($" Time needed: {result} milliseconds");
        }
    }

    public static class StopwatchMiddlewareExtension
    {
        public static IApplicationBuilder UseStopwatch(this IApplicationBuilder app)
        {
            app.UseMiddleware<StopwatchMiddleware>();
            return app;
        }
    }

}