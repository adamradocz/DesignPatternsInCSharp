namespace DesignPatternsInCSharp.Structural.Bridge.Naiv;

public class SpecialOneMonthSubscription : OneMonthSubscription
{
    public SpecialOneMonthSubscription(DateTime purchaseTime)
        : base(purchaseTime)
    {
    }

    public override decimal GetPrice() => base.GetPrice() * 0.9m;
}
