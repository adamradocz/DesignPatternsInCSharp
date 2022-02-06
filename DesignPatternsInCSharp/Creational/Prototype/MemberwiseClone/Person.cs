namespace DesignPatternsInCSharp.Creational.Prototype.MemberwiseClone;

public class Person : IPrototype<Person>
{
    public int Age { get; set; }
    public string? Name { get; set; }
    public Address Address { get; set; } = new();

    public Person ShallowClone() => (Person)MemberwiseClone();

    public Person DeepClone()
    {
        Person other = (Person)MemberwiseClone();
        other.Address = Address.DeepClone();
        return other;
    }
}
