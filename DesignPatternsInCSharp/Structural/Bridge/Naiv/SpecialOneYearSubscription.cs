namespace DesignPatternsInCSharp.Structural.Bridge.Naiv;

public class SpecialOneYearSubscription : OneYearSubscription
{
    public SpecialOneYearSubscription(DateTime purchaseTime)
        : base(purchaseTime)
    {
    }

    public override decimal GetPrice() => base.GetPrice() * 0.9m;
}
