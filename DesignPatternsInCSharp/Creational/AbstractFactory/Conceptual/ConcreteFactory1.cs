using DesignPatternsInCSharp.Creational.AbstractFactory.Conceptual.Interfaces;

namespace DesignPatternsInCSharp.Creational.AbstractFactory.Conceptual;

public class ConcreteFactory1 : IAbstractFactory
{
    public IAbstractProductA CreateProductA() => new ConcreteProductA1();
    public IAbstractProductB CreateProductB() => new ConcreteProductB1();
}