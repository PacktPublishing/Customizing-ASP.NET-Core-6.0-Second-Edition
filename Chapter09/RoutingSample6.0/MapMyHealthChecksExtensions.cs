namespace RoutingSample;
public static class MapMyHealthChecksExtensions
{
    public static IEndpointConventionBuilder MapMyHealthChecks(
        this IEndpointRouteBuilder endpoints, string pattern = "/myhealth")
    {
        var pipeline = endpoints
            .CreateApplicationBuilder()
            .UseMiddleware<MyHealthChecksMiddleware>()
            .Build();

        return endpoints.Map(pattern, pipeline)
            .WithDisplayName("My custom health checks");

    }
}
