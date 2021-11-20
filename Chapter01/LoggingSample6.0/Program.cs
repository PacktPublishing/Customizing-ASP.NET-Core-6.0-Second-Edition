using LoggingSample;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);


// builder.Logging.ClearProviders();
// builder.Logging.SetMinimumLevel(LogLevel.Trace);

builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Logging.ClearProviders();
// var config = new ColoredConsoleLoggerConfiguration
// {
//     LogLevel = LogLevel.Information,
//     Color = ConsoleColor.Red
// };
// builder.Logging.AddProvider(new ColoredConsoleLoggerProvider(config));

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
