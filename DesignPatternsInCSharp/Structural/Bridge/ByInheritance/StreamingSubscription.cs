namespace DesignPatternsInCSharp.Structural.Bridge.ByInheritance;

public abstract class StreamingSubscription
{
    private readonly Discount _discount;

    public DateTime PurchaseTime { get; }

    protected StreamingSubscription(DateTime purchaseTime, Discount discount)
    {
        PurchaseTime = purchaseTime;
        _discount = discount;
    }

    public decimal GetPrice()
    {
        var discount = _discount.GetDiscount();
        var multiplier = 1 - discount / 100m;
        return GetPriceCore() * multiplier;
    }

    protected abstract decimal GetPriceCore();
    public abstract DateTime? GetExpirationDate();
}
