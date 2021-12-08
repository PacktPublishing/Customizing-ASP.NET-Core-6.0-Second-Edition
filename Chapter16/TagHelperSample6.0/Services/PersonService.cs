using TagHelperSample.Models;
using GenFu;

namespace TagHelperSample.Services;

public interface IService
{
    IEnumerable<Person> AllPersons();
}
internal class PersonService : IService
{
    public IEnumerable<Person> AllPersons()
    {
        return A.ListOf<Person>(25);
    }
}
