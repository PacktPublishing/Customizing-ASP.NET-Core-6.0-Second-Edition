using LoggingSample;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureLogging((hostingContext, logging) =>
{
    
    // logging.ClearProviders();
    // logging.SetMinimumLevel(LogLevel.Trace);

    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
    logging.AddConsole();
    logging.AddDebug();

    // logging.ClearProviders();
    // var config = new ColoredConsoleLoggerConfiguration
    // {
    //     LogLevel = LogLevel.Information,
    //     Color = ConsoleColor.Red
    // };
    // logging.AddProvider(new ColoredConsoleLoggerProvider(config));
    
});
builder.WebHost.UseNLog();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
