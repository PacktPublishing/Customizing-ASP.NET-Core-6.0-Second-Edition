
using System.ComponentModel.DataAnnotations;
using ActionFilterSample;
using Microsoft.AspNetCore.Mvc;

namespace OutputFormatterSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        [HttpPost]
        [ValidateModel]
        public ActionResult<Person> Post([FromBody] Person model)
        {
            return model;
        }
    }


    public class Person
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}