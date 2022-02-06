namespace DesignPatternsInCSharp.Creational.Prototype.MemberwiseClone;

public class Address : IPrototype<Address>
{
    public string? StreetName { get; set; }
    public int HouseNumber { get; set; }

    public Address ShallowClone() => (Address)MemberwiseClone();

    public Address DeepClone() => (Address)MemberwiseClone();
}
