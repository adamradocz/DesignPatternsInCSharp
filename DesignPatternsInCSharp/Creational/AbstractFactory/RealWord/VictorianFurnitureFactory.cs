using DesignPatternsInCSharp.Creational.AbstractFactory.RealWord.Interfaces;
using DesignPatternsInCSharp.Creational.AbstractFactory.RealWord.Models;

namespace DesignPatternsInCSharp.Creational.AbstractFactory.RealWord;

public class VictorianFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair() => new VictorianChair();
    public ICoffeeTable CreateCoffeeTable() => new VictorianCoffeeTable();
    public ISofa CreateSofa() => new VictorianSofa();
}
