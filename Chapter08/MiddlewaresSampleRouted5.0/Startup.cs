using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MiddlewaresSampleRouted
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapAppStatus("/status", "Status");
            });
        }
    }

    public static class MapAppStatusMiddlewareExtension
    {
        public static IEndpointConventionBuilder MapAppStatus(
            this IEndpointRouteBuilder routes,
            string pattern = "/", string name = "World")
        {
            var pipeline = routes.CreateApplicationBuilder()
                .UseMiddleware<AppStatusMiddleware>(name)
                .Build();

            return routes.Map(pattern, pipeline)
                .WithDisplayName("AppStatusMiddleware");
        }
    }

    public class AppStatusMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _name;

        public AppStatusMiddleware(RequestDelegate next, string name)
        {
            _next = next;
            _name = name;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync($"Hello {_name}!");
        }
    }
}
