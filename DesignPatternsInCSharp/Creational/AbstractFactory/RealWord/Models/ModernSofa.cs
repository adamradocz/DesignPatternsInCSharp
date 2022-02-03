using DesignPatternsInCSharp.Creational.AbstractFactory.RealWord.Interfaces;

namespace DesignPatternsInCSharp.Creational.AbstractFactory.RealWord.Models;

public class ModernSofa : ISofa
{
    public string Name { get; set; } = "Epic";
    public string Manufacturer { get; set; } = "Noblesofa";
}
