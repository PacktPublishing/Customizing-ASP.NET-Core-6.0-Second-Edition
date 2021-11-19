using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CacheSample.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;

namespace CacheSample.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMemoryCache _cache;

    public HomeController(ILogger<HomeController> logger, IMemoryCache cache, IDistributedCache distcache)
    {
        _logger = logger;
        _cache = cache;
    }

    //[ResponseCache(CacheProfileName = "Duration30")]
    public IActionResult Index()
    {
        if (!_cache.TryGetValue<string>("IndexKey1", out var message1))
        {
            message1 = $"The current time is: {DateTime.Now.ToLongTimeString()}";
            _cache.Set("IndexKey1", message1, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromSeconds(6)
            });
        }

        var message2 = _cache.GetOrCreate("Index", entry =>
        {
            entry.SlidingExpiration = TimeSpan.FromSeconds(5);
            return $"The current time is: {DateTime.Now.ToLongTimeString()}";
        });

        return View(new IndexViewModel
        {
            Message1 = message1,
            Message2 = message2
        });
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
