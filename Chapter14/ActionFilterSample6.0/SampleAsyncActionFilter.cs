using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFilterSample;

public class SampleAsyncActionFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
    {
        // do something before the action executes
        var resultContext = await next();
        // do something after the action executes; resultContext.Result will be set
    }
}

