namespace DesignPatternsInCSharp.Structural.Decorator.RealLife;

public class Sedan : ICar
{
    public Sedan(int basePrice)
    {
        Price = basePrice;
    }

    public int Price { get; set; }

    public List<string> Extras { get; } = new();
}
