using DesignPatternsInCSharp.Creational.AbstractFactory.RealWord.Interfaces;

namespace DesignPatternsInCSharp.Creational.AbstractFactory.RealWord.Models;

public class ModernCoffeeTable : ICoffeeTable
{
    public string Name { get; set; } = "Doom";
    public string Manufacturer { get; set; } = "Nobletables";
}
