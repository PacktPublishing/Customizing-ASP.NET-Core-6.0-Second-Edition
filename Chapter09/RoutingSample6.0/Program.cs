using Microsoft.AspNetCore.Builder;
using RoutingSample;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.Map("/map", async context =>
{
    await context.Response.WriteAsync("OK");
});
app.MapGet("/mapget", async context =>
{
    await context.Response.WriteAsync("Map GET");
});
app.MapPost("/mappost", async context =>
{
    await context.Response.WriteAsync("Map POST");
});
app.MapPut("/mapput", async context =>
{
    await context.Response.WriteAsync("Map PUT");
});
app.MapDelete("/mapdelete", async context =>
{
    await context.Response.WriteAsync("Map DELETE");
});
app.MapMethods("/mapmethods", new[] { "DELETE", "PUT" }, async context =>
{
    await context.Response.WriteAsync("Map Methods");
});

app.MapMyHealthChecks();
app.MapMyHealthChecks("/myhealth1");

app.UseEndpoints(endpoints =>
{
    endpoints.Map("/myhealth2", endpoints.CreateApplicationBuilder()
        .UseMiddleware<MyHealthChecksMiddleware>()
        .Build());
});

app.Map("/myhealth3", context =>
{
    context.UseMiddleware<MyHealthChecksMiddleware>();
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
