using DesignPatternsInCSharp.Creational.AbstractFactory.RealWord.Interfaces;

namespace DesignPatternsInCSharp.Creational.AbstractFactory.RealWord.Models;

public class ModernChair : IChair
{
    public string Name { get; set; } = "Hero";
    public string Manufacturer { get; set; } = "Noblechairs";
}
