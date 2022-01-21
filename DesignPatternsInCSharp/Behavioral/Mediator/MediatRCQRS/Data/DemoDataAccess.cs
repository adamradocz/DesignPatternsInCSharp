using DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Models;

namespace DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Data;

public class DemoDataAccess
{
    private List<Person> people = new();

    public DemoDataAccess()
    {
        people.Add(new Person { Id = 1, FirstName = "David", LastName = "Fowler" });
        people.Add(new Person { Id = 2, FirstName = "Sue", LastName = "Storm" });
    }

    public List<Person> GetPeople() => people;

    public Person InsertPerson(string firstName, string lastName)
    {
        Person p = new() { FirstName = firstName, LastName = lastName };
        p.Id = people.Max(x => x.Id) + 1;
        people.Add(p);
        return p;
    }
}