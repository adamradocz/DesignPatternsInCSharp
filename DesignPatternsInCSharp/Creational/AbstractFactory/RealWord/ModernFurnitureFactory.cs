using DesignPatternsInCSharp.Creational.AbstractFactory.RealWord.Interfaces;
using DesignPatternsInCSharp.Creational.AbstractFactory.RealWord.Models;

namespace DesignPatternsInCSharp.Creational.AbstractFactory.RealWord;

public class ModernFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair() => new ModernChair();
    public ICoffeeTable CreateCoffeeTable() => new ModernCoffeeTable();
    public ISofa CreateSofa() => new ModernSofa();
}
