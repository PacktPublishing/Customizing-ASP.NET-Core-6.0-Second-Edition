using System.Net;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

/*
// kestrel options, remove for IIS usage
builder.WebHost.UseKestrel((host, options) =>
{
    var filename = host.Configuration.GetValue(
        "AppSettings:certfilename", "");
    var password = host.Configuration.GetValue(
        "AppSettings:certpassword", "");

    options.Listen(IPAddress.Loopback, 5000);
    options.Listen(IPAddress.Loopback,  5001,  
        listenOptions  =>
        {
            listenOptions.UseHttps(filename, password);
        });
});
*/

/*
// => needed for Nginx or Apache Hosting
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.KnownProxies.Add(
        IPAddress.Parse("10.0.0.100"));
});
*/

var app = builder.Build();

/*
// => needed for Nginx or Apache Hosting
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor 
        | ForwardedHeaders.XForwardedProto
});
*/

app.MapGet("/", () => "Hello World!");

app.Run();
