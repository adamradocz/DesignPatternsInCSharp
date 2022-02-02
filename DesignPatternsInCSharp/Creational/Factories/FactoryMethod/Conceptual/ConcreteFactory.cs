namespace DesignPatternsInCSharp.Creational.Factories.FactoryMethod.Conceptual;

public class ConcreteFactory : FactoryBase
{
    public override IProduct CreateProduct(char productCode)
    {
        if (productCode == 'A')
        {
            return new ProductA();
        }

        if (productCode == 'B')
        {
            return new ProductB();
        }

        throw new ArgumentException("Invalid product code");
    }
}
