namespace DesignPatternsInCSharp.Structural.Bridge.Naiv;

public class SeniorOneYearSubscription : OneYearSubscription
{
    public SeniorOneYearSubscription(DateTime purchaseTime)
        : base(purchaseTime)
    {
    }

    public override decimal GetPrice() => base.GetPrice() * 0.8m;
}
