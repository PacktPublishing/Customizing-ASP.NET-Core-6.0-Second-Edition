using GenFu;
using Microsoft.AspNetCore.Mvc;
using OutputFormatterSample.Models;

namespace OutputFormatterSample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Person>> Get()
    {
        var persons = A.ListOf<Person>(25);
        return persons;
    }
}
