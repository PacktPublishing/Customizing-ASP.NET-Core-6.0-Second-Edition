using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MiddleWaresSample
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.Use(async (context, next) =>
            // {
            //     var s = new Stopwatch();
            //     s.Start();
            //     await next();
            //     s.Stop();
            //     var result = s.ElapsedMilliseconds;
            //     await context.Response.WriteAsync($"Time needed: {result }");
            // });

            //app.UseMiddleware<StopwatchMiddleWare>();
            
            app.UseStopwatch();

            // app.Map("/map1", app1 =>
            // {
            //     app1.Run(async context =>
            //     {
            //         await context.Response.WriteAsync("Map Test 1");
            //     });
            // });
            // app.Map("/map2", app1 =>
            // {
            //     app1.Run(async context =>
            //     {
            //         await context.Response.WriteAsync("Map Test 2");
            //     });
            // });

            // app.Use(async (context, next) =>
            // {
            //     await context.Response.WriteAsync(" ===");
            //     await next();
            //     await context.Response.WriteAsync("=== ");
            // });
            // app.Use(async (context, next) =>
            // {
            //     await context.Response.WriteAsync(">>>>>> ");
            //     await next();
            //     await context.Response.WriteAsync(" <<<<<<");
            // });

            app.UseMvc();
        }
    }

    public class StopwatchMiddleWare
    {
        private readonly RequestDelegate _next;

        public StopwatchMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var s = new Stopwatch();
            s.Start();
            await _next(context);
            s.Stop();
            var result = s.ElapsedMilliseconds;
            await context.Response.WriteAsync($" Time needed: {result }");
        }
    }

    public static class StopwatchMiddleWareExtension
    {
        public static IApplicationBuilder UseStopwatch(this IApplicationBuilder app)
        {
            app.UseMiddleware<StopwatchMiddleWare>();
            return app;
        }
    }
}
