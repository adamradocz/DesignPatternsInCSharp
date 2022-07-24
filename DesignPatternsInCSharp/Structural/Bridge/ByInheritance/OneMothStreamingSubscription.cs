namespace DesignPatternsInCSharp.Structural.Bridge.ByInheritance;

public class OneMothStreamingSubscription : StreamingSubscription
{
    public OneMothStreamingSubscription(DateTime purchaseTime, Discount discount)
        : base(purchaseTime, discount)
    {
    }

    protected override decimal GetPriceCore() => 4;
    public override DateTime? GetExpirationDate() => PurchaseTime.AddMonths(1);
}
