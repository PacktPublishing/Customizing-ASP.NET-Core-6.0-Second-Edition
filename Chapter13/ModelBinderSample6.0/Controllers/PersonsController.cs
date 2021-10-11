using Microsoft.AspNetCore.Mvc;
using ModelBinderSample.Models;

namespace ModelBinderSample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonsController : ControllerBase
{
    public ActionResult<object> Post(
        [ModelBinder(binderType: typeof(PersonsCsvBinder))]
        IEnumerable<Person> persons)
    {
        return new
        {
            ItemsRead = persons.Count(),
            Persons = persons
        };
    }
}
