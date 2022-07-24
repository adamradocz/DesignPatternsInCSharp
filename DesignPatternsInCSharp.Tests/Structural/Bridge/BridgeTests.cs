using DesignPatternsInCSharp.Structural.Bridge.ByComposition;
using DesignPatternsInCSharp.Structural.Bridge.ByInheritance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesignPatternsInCSharp.Tests.Structural.Bridge;

[TestClass]
public class BridgeTests
{
    [TestMethod]
    public void Composition_CreateStreamingSubscriptions_WithTheSameSubscriptionTypeTheyGiveSameResult()
    {
        //Arrange  
        var now = DateTime.Now;
        var oneMothStreamingSubscription = new DesignPatternsInCSharp.Structural.Bridge.ByComposition.StreamingSubscription(now, DesignPatternsInCSharp.Structural.Bridge.ByComposition.Discount.None, SubscriptionType.OneMonth);
        var oneYearStreamingSubscription = new DesignPatternsInCSharp.Structural.Bridge.ByComposition.StreamingSubscription(now, DesignPatternsInCSharp.Structural.Bridge.ByComposition.Discount.None, SubscriptionType.OneYear);
        var oneYearStreamingSubscriptionWithSpecialDiscount = new DesignPatternsInCSharp.Structural.Bridge.ByComposition.StreamingSubscription(now, DesignPatternsInCSharp.Structural.Bridge.ByComposition.Discount.Special, SubscriptionType.OneYear);
        var oneMothStreamingSubscriptionWithSeniorDiscount = new DesignPatternsInCSharp.Structural.Bridge.ByComposition.StreamingSubscription(now, DesignPatternsInCSharp.Structural.Bridge.ByComposition.Discount.Senior, SubscriptionType.OneMonth);

        // Act
        
        //Assert
        Assert.AreNotEqual(oneMothStreamingSubscription.GetPrice(), oneMothStreamingSubscriptionWithSeniorDiscount.GetPrice());
        Assert.AreNotEqual(oneYearStreamingSubscription.GetPrice(), oneYearStreamingSubscriptionWithSpecialDiscount.GetPrice());
        Assert.AreEqual(oneYearStreamingSubscription.GetExpirationDate(), oneYearStreamingSubscriptionWithSpecialDiscount.GetExpirationDate());
        Assert.AreEqual(oneMothStreamingSubscription.GetExpirationDate(), oneMothStreamingSubscriptionWithSeniorDiscount.GetExpirationDate());
    }

    [TestMethod]
    public void Inheritance_CreateStreamingSubscriptions_WithTheSameSubscriptionTypeTheyGiveSameResult()
    {
        //Arrange  
        var now = DateTime.Now;
        var noDiscount = new NoDiscount();
        var oneMothStreamingSubscription = new OneMothStreamingSubscription(now, noDiscount);
        var oneYearStreamingSubscription = new OneYearStreamingSubscription(now, noDiscount);

        var specialDiscount = new SpecialDiscount();
        var seniorDiscount = new SeniorDiscount();
        var oneMothStreamingSubscriptionWithSeniorDiscount = new OneMothStreamingSubscription(now, specialDiscount);
        var oneYearStreamingSubscriptionWithSpecialDiscount = new OneYearStreamingSubscription(now, seniorDiscount);

        // Act

        //Assert
        Assert.AreNotEqual(oneMothStreamingSubscription.GetPrice(), oneMothStreamingSubscriptionWithSeniorDiscount.GetPrice());
        Assert.AreNotEqual(oneYearStreamingSubscription.GetPrice(), oneYearStreamingSubscriptionWithSpecialDiscount.GetPrice());
        Assert.AreEqual(oneYearStreamingSubscription.GetExpirationDate(), oneYearStreamingSubscriptionWithSpecialDiscount.GetExpirationDate());
        Assert.AreEqual(oneMothStreamingSubscription.GetExpirationDate(), oneMothStreamingSubscriptionWithSeniorDiscount.GetExpirationDate());
    }
}
