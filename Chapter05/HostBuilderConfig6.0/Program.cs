using System;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder.UseKestrel((host, options) =>
    {
        var filename = host.Configuration.GetValue("AppSettings:certfilename", "");
        var password = host.Configuration.GetValue("AppSettings:certpassword", "");

        options.Listen(IPAddress.Loopback, 5000);
        options.Listen(IPAddress.Loopback, 5001, listenOptions =>
        {
            listenOptions.UseHttps(filename, password);
        });
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", () => "Hello World!");

app.Run();
