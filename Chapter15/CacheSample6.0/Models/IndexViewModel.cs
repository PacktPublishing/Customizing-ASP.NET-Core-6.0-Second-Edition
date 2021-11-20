using System.Runtime.Intrinsics.X86;

namespace CacheSample.Models;
internal class IndexViewModel
{
    public IEnumerable<Person>? Persons { get; set; }
    public IDictionary<int, string>? Data { get; set; }
}

internal class Person
{
    public int Id { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
}