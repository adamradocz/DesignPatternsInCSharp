namespace DesignPatternsInCSharp.Structural.Decorator.RealLife;

public interface ICar
{
    public int Price { get; set; }

    public List<string> Extras { get; }
}
