namespace DesignPatternsInCSharp.Structural.Bridge.ByInheritance;

public class OneYearStreamingSubscription : StreamingSubscription
{
    public OneYearStreamingSubscription(DateTime purchaseTime, Discount discount)
        : base(purchaseTime, discount)
    {
    }

    protected override decimal GetPriceCore() => 8;
    public override DateTime? GetExpirationDate() => PurchaseTime.AddYears(1);
}