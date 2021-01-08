using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace HttpSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseKestrel(options =>
                        {
                            options.Listen(IPAddress.Loopback, 5000);
                            options.Listen(IPAddress.Loopback, 5001, listenOptions =>
                            {
                                listenOptions.UseHttps("certificate.pfx", "topsecret");
                            });
                        })
                        .UseStartup<Startup>();
                });
    }
}
