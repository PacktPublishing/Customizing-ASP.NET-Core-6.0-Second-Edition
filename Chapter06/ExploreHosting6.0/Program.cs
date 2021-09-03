using System.Net;

var builder = WebApplication.CreateBuilder(args);

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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", () => "Hello World!");

app.Run();
