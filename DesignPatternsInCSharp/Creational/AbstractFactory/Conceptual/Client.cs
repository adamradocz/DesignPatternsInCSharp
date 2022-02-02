using DesignPatternsInCSharp.Creational.AbstractFactory.Conceptual.Interfaces;

namespace DesignPatternsInCSharp.Creational.AbstractFactory.Conceptual;

public class Client
{
    private readonly IAbstractProductA _abstractProductA;
    private readonly IAbstractProductB _abstractProductB;

    public Client(IAbstractFactory factory)
    {
        _abstractProductA = factory.CreateProductA();
        _abstractProductB = factory.CreateProductB();
    }

    public void Run()
    {
        _abstractProductA.UsefulFunctionA();
        _abstractProductB.UsefulFunctionB();
        _abstractProductB.AnotherUsefulFunctionB(_abstractProductA);
    }
}
