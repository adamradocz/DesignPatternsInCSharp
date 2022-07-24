namespace DesignPatternsInCSharp.Structural.Bridge.Naiv;

public class OneYearSubscription : StreamingSubscription
{
    public OneYearSubscription(DateTime purchaseTime)
        : base(purchaseTime)
    {
    }

    public override decimal GetPrice() => 8;

    public override DateTime? GetExpirationDate() => PurchaseTime.AddYears(1);
}
