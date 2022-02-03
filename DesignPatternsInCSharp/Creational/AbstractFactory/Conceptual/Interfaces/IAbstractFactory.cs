namespace DesignPatternsInCSharp.Creational.AbstractFactory.Conceptual.Interfaces;

public interface IAbstractFactory
{
    IAbstractProductA CreateProductA();
    IAbstractProductB CreateProductB();
}
