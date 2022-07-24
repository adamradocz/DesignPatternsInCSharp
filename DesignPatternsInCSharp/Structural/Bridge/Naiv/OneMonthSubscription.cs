namespace DesignPatternsInCSharp.Structural.Bridge.Naiv;

public class OneMonthSubscription : StreamingSubscription
{
    public OneMonthSubscription(DateTime purchaseTime)
        : base(purchaseTime)
    {
    }

    public override decimal GetPrice() => 4;

    public override DateTime? GetExpirationDate() => PurchaseTime.AddMonths(1);
}
