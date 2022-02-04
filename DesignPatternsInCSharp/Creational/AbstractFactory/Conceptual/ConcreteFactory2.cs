using DesignPatternsInCSharp.Creational.AbstractFactory.Conceptual.Interfaces;

namespace DesignPatternsInCSharp.Creational.AbstractFactory.Conceptual;

public class ConcreteFactory2 : IAbstractFactory
{
    public IAbstractProductA CreateProductA() => new ConcreteProductA2();
    public IAbstractProductB CreateProductB() => new ConcreteProductB2();
}
