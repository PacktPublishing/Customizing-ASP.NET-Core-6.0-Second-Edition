using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace DiSample;

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

