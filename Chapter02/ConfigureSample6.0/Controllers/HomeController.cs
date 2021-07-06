using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ConfigureSample.Models;
using Microsoft.Extensions.Options;

namespace ConfigureSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppSettings _options;

        public HomeController(IOptions<AppSettings> options)
        {
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
}
