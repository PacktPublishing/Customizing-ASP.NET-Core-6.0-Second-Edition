using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.CacheProfiles.TryAdd("Duration30",
        new CacheProfile
        {
            Duration = 30, 
            VaryByHeader = "User-Agent", 
            Location = ResponseCacheLocation.Client
        });
    options.CacheProfiles.TryAdd("Duration60",
        new CacheProfile
        {
            Duration = 60, 
            VaryByHeader = "User-Agent", 
            Location = ResponseCacheLocation.Client
        });
});

// builder.Services.AddMemoryCache();
// builder.Services.AddResponseCaching();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

const string cacheMaxAge = "86400";
app.UseStaticFiles(new StaticFileOptions()
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.TryAdd(
            "Cache-Control", $"public, max-age={cacheMaxAge}");
    }
});

//app.UseResponseCaching();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
