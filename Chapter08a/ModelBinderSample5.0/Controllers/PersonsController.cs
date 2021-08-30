
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ModelBinderSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        [HttpPost]
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
    [ModelBinder(BinderType = typeof(PersonsCsvBinder))]
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
    }

    public class PersonsCsvBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                return;
            }

            var modelName = bindingContext.ModelName;
            if (String.IsNullOrEmpty(modelName))
            {
                modelName = bindingContext.OriginalModelName;
            }
            if (String.IsNullOrEmpty(modelName))
            {
                return;
            }

            // Try to fetch the value of the argument by name
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
            if (valueProviderResult == ValueProviderResult.None)
            {
                return;
            }

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            var value = valueProviderResult.FirstValue;
            // Check if the argument value is null or empty
            if (String.IsNullOrEmpty(value))
            {
                return;
            }

            var stringReader = new StringReader(value);
            var reader = new CsvReader(stringReader, CultureInfo.InvariantCulture);

            var asyncModel = reader.GetRecordsAsync<Person>();
            var model = await asyncModel.ToListAsync();
            bindingContext.Result = ModelBindingResult.Success(model);
        }
    }
}