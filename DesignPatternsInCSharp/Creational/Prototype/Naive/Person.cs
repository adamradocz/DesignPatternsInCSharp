namespace DesignPatternsInCSharp.Creational.Prototype.Naive;

public class Person : IPrototype<Person>
{
    public int Age { get; set; }
    public string? Name { get; set; }
    public Address Address { get; set; } = new();

    public Person ShallowClone()
    {
        return new Person()
        {
            Age = Age,
            Name = Name,
            Address = Address
        };
    }

    public Person DeepClone()
    {
        return new Person()
        {
            Age = Age,
            Name = Name,
            Address = Address.ShallowClone()
        };
    }
}
