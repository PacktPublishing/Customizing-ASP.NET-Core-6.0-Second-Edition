using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using CacheSample.Models;
using GenFu;

namespace CacheSample.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMemoryCache _cache;

    public HomeController(
        ILogger<HomeController> logger,
        IMemoryCache cache
        )
    {
        _logger = logger;
        _cache = cache;
    }

    private IEnumerable<Person> LoadDataFromExternalSource()
    {
        return A.ListOf<Person>(10);
    }

    private IDictionary<int, string> LoadSuperComplexCalculatedData()
    {
        return Enumerable.Range(0, 10)
            .ToDictionary(x => x, x => $"Item{Random.Shared.Next()}");
    }

    //[ResponseCache(CacheProfileName = "Duration30")]
    public IActionResult Index()
    {
        if (!_cache.TryGetValue<IEnumerable<Person>>(
            "ExternalSource", out var externalPersons))
        {
            externalPersons = LoadDataFromExternalSource();
            _cache.Set(
                "ExternalSource",
                externalPersons,
                new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(30)
                });
        }

        var calculatedValues = _cache.GetOrCreate(
            "ComplexCalculate", entry =>
        {
            entry.AbsoluteExpiration = DateTime.Now.AddSeconds(30);
            return LoadSuperComplexCalculatedData();
        });

        return View(new IndexViewModel
        {
            Persons = externalPersons,
            Data = calculatedValues
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
