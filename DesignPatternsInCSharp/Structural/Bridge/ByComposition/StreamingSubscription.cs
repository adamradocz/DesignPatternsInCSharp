namespace DesignPatternsInCSharp.Structural.Bridge.ByComposition;

public class StreamingSubscription
{
    private readonly Discount _discount;
    private readonly SubscriptionType _subscriptionType;

    public DateTime PurchaseTime { get; }

    public StreamingSubscription(DateTime purchaseTime, Discount discount, SubscriptionType subscriptionType)
    {
        _discount = discount;
        _subscriptionType = subscriptionType;

        PurchaseTime = purchaseTime;
    }

    public decimal GetPrice()
    {
        var discount = GetDiscount();
        var multiplier = 1 - discount / 100m;
        return GetBasePrice() * multiplier;
    }

    private int GetDiscount()
    {
        return _discount switch
        {
            Discount.None => 0,
            Discount.Special => 10,
            Discount.Senior => 20,

            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private decimal GetBasePrice()
    {
        return _subscriptionType switch
        {
            SubscriptionType.OneMonth => 4,
            SubscriptionType.OneYear => 8,

            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public DateTime? GetExpirationDate()
    {
        return _subscriptionType switch
        {
            SubscriptionType.OneMonth => PurchaseTime.AddMonths(1),
            SubscriptionType.OneYear => PurchaseTime.AddYears(1),

            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
