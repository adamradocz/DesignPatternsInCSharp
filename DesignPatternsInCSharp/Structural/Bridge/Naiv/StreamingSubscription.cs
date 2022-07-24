namespace DesignPatternsInCSharp.Structural.Bridge.Naiv;

public abstract class StreamingSubscription
{
    public DateTime PurchaseTime { get; }

    protected StreamingSubscription(DateTime purchaseTime)
    {
        PurchaseTime = purchaseTime;
    }

    public abstract decimal GetPrice();
    public abstract DateTime? GetExpirationDate();
}
