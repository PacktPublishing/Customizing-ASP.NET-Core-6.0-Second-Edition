using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TagHelperSample.Models;
using TagHelperSample.Services;

namespace TagHelperSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService _service;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "Your application description page.";

            var persons = _service.AllPersons();

            return View(new IndexViewModel
            {
                Persons = persons
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

    public class IndexViewModel
    {
        public IEnumerable<Person> Persons { get; set; }
    }
}
