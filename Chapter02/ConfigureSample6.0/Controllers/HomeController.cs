using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ConfigureSample.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace ConfigureSample.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppSettings _options;

    public HomeController(
        ILogger<HomeController> logger, 
        IOptions<AppSettings> options)
    {
        _logger = logger;
        _options = options.Value;
    }

    public IActionResult Index()
    {
        ViewData["Message"] = _options.Bar;
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
