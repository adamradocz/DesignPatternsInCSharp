namespace DesignPatternsInCSharp.Creational.Prototype.Naive;

public class Address : IPrototype<Address>
{
    public string? StreetName { get; set; }
    public int HouseNumber { get; set; }

    public Address ShallowClone()
    {
        return new Address()
        {
            StreetName = StreetName,
            HouseNumber = HouseNumber
        };
    }

    public Address DeepClone()
    {
        return new Address()
        {
            StreetName = StreetName,
            HouseNumber = HouseNumber
        };
    }
}
