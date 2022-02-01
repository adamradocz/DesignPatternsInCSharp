namespace DesignPatternsInCSharp.Creational.Factories.FactoryMethod.Conceptual;

public abstract class FactoryBase
{
    public abstract IProduct CreateProduct(char productCode);
}
