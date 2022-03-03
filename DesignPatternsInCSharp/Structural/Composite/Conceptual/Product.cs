namespace DesignPatternsInCSharp.Structural.Composite.Conceptual;

/// <summary>
/// The Leaf class
/// </summary>
public class Product : IProductComponent
{
    private readonly decimal _price;

    public Product(decimal price)
    {
        _price = price;
    }

    // Demonstrate a complex operation.
    public decimal CalculatePrice() => _price;
}
