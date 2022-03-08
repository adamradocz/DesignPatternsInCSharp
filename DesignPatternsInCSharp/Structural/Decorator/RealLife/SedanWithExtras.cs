namespace DesignPatternsInCSharp.Structural.Decorator.RealLife;

public class SedanWithExtras : ICar
{
    protected readonly ICar Car;

    public SedanWithExtras(ICar car)
    {
        Car = car ?? throw new ArgumentNullException(nameof(car));
    }

    public int Price
    {
        get { return Car.Price; }
        set { Car.Price = value; }
    }

    public List<string> Extras => Car.Extras;
}
