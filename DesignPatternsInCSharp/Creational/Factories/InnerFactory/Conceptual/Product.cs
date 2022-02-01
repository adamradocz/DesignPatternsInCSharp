namespace DesignPatternsInCSharp.Creational.Factories.InnerFactory.Conceptual;

public class Product
{
    private Product()
    {
    }

    public string Operation() => nameof(Product);

    public static class Factory
    {
        public static Product Create() => new();
    }
}
