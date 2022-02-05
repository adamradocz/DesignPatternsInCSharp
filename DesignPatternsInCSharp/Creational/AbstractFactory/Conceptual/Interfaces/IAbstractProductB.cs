namespace DesignPatternsInCSharp.Creational.AbstractFactory.Conceptual.Interfaces;

public interface IAbstractProductB
{
    string UsefulFunctionB();
    string AnotherUsefulFunctionB(IAbstractProductA collaborator);
}
