using System.Diagnostics;
using MiddlewaresSample;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// app.Use(async (context, next) =>
// {
//     var s = new Stopwatch();
//     s.Start();

//     // execute the rest of the pipeline
//     await next();

//     s.Stop(); //stop measuring
//     var result = s.ElapsedMilliseconds;

//     // write out the milliseconds needed
//     await context.Response.WriteAsync($" Time needed: {result} milliseconds");
// });

// app.UseMiddleware<StopwatchMiddleware>();

// app.UseStopwatch();

// app.Use(async (context, next) =>
// {
//     await context.Response.WriteAsync("===");
//     await next();
//     await context.Response.WriteAsync("===");
// });

// app.Use(async (context, next) =>
// {
//     await context.Response.WriteAsync(">>>>>> ");
//     await next();
//     await context.Response.WriteAsync(" <<<<<<");
// });

// app.Run(async context =>
// {
//     await context.Response.WriteAsync("Hello World!");
// });

//app.MapGet("/", () => "Hello World!");

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", () => "Hello World!");
    endpoints.MapAppStatus("/status", "Status");
});

app.Run();
