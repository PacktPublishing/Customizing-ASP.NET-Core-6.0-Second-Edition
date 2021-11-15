using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CacheSample.Models;
using Microsoft.Extensions.Caching.Memory;

namespace CacheSample.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMemoryCache _cache;

    public HomeController(ILogger<HomeController> logger, IMemoryCache cache)
    {
        _logger = logger;
        _cache = cache;
    }

    public IActionResult Index()
    {
        var message = _cache.GetOrCreate("Index", key =>
        {
            return $"The current time is: {DateTime.Now.ToLongTimeString()}";
        });
        return View();
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
