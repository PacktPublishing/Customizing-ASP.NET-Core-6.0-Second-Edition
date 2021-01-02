using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace RoutingSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.Map("/map", async context =>
                {
                    await context.Response.WriteAsync("OK");
                });
                endpoints.MapGet("/mapget", async context =>
                {
                    await context.Response.WriteAsync("Map GET");
                });
                endpoints.MapPost("/mappost", async context =>
                {
                    await context.Response.WriteAsync("Map POST");
                });
                endpoints.MapPut("/mapput", async context =>
                {
                    await context.Response.WriteAsync("Map PUT");
                });
                endpoints.MapDelete("/mapdelete", async context =>
                {
                    await context.Response.WriteAsync("Map DELETE");
                });
                endpoints.MapMethods("/mapmethods", new[] { "DELETE", "PUT" }, async context =>
                {
                    await context.Response.WriteAsync("Map Methods");
                });


                endpoints.MapMyHealthChecks();
                endpoints.MapMyHealthChecks("/myhealth1");

                endpoints.Map("/myhealth2", endpoints.CreateApplicationBuilder()
                    .UseMiddleware<MyHealthChecksMiddleware>()
                    .Build())
                    .WithDisplayName("My custom health checks");

                //endpoints.MapHealthChecks("/healthz"); 

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }


    public static class MapMyHealthChecksExtensions
    {
        public static IEndpointConventionBuilder MapMyHealthChecks(
            this IEndpointRouteBuilder endpoints, string pattern = "/myhealth")
        {
            var pipeline = endpoints
                .CreateApplicationBuilder()
                .UseMiddleware<MyHealthChecksMiddleware>()
                .Build();

            return endpoints.Map(pattern, pipeline)
                .WithDisplayName("My custom health checks");

        }
    }

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
