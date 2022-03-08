namespace DesignPatternsInCSharp.Structural.Facade;

public class Customer
{
    public string Name { get; }

    public Customer(string name)
    {
        Name = name;
    }
}