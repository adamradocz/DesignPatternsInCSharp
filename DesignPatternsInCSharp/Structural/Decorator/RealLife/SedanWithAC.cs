namespace DesignPatternsInCSharp.Structural.Decorator.RealLife;

public class SedanWithAC : SedanWithExtras
{
    public SedanWithAC(ICar car) : base(car)
    {
        Car.Extras.Add("Air Conditioner");
        Car.Price += 200;
    }
}
