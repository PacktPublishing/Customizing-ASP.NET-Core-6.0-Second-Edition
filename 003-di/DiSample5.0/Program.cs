using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Autofac.Extensions.DependencyInjection;
using Autofac;

namespace DiSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseAutofacServiceProviderFactory()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    public static class IHostBuilderExtension
    {
        public static IHostBuilder UseAutofacServiceProviderFactory(
            this IHostBuilder hostbuilder)
        {
            hostbuilder.UseServiceProviderFactory<ContainerBuilder>(
                new AutofacServiceProviderFactory());
            return hostbuilder;
        }
    }
}
