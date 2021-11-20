using GenFu;

namespace DiSample;

public interface IService
{
    IEnumerable<Person> AllPersons();
}

internal class MyService : IService
{
    public IEnumerable<Person> AllPersons()
    {
        return A.ListOf<Person>(25);
    }
}

public class Person
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Age { get; set; }
    public string? EmailAddress { get; set; }
}
