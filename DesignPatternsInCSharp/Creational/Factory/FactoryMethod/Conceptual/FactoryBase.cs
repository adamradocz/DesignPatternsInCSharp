namespace DesignPatternsInCSharp.Creational.Factory.FactoryMethod.Conceptual;

public abstract class FactoryBase
{
    public abstract IProduct CreateProduct(char productCode);
}
