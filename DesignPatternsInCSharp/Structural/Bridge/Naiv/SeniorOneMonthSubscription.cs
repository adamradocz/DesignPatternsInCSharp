namespace DesignPatternsInCSharp.Structural.Bridge.Naiv;

public class SeniorOneMonthSubscription : OneMonthSubscription
{
    public SeniorOneMonthSubscription(DateTime purchaseTime)
        : base(purchaseTime)
    {
    }

    public override decimal GetPrice() => base.GetPrice() * 0.8m;
}
