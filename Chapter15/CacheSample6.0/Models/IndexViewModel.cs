namespace CacheSample.Models;

internal class IndexViewModel
{
    public IEnumerable<Person>? Persons { get; set; }
    public IDictionary<int, string>? Data { get; set; }
}
