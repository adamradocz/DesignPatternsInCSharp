namespace DesignPatternsInCSharp.Creational.AbstractFactory.RealWord.Interfaces;

public interface IFurnitureFactory
{
    IChair CreateChair();
    ICoffeeTable CreateCoffeeTable();
    ISofa CreateSofa();
}
