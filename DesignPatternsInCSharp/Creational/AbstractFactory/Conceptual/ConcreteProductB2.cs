using DesignPatternsInCSharp.Creational.AbstractFactory.Conceptual.Interfaces;

namespace DesignPatternsInCSharp.Creational.AbstractFactory.Conceptual;

internal class ConcreteProductB2 : IAbstractProductB
{
    public string AnotherUsefulFunctionB(IAbstractProductA collaborator)
    {
        string result = collaborator.UsefulFunctionA();
        return $"The result of the B2 collaborating with the ({result})";
    }
    public string UsefulFunctionB() => "The result of the product B2.";
}
