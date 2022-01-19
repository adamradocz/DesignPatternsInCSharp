using DesignPatternsInCSharp.Behavioral.Observer;
using DesignPatternsInCSharp.Behavioral.Observer.Implementations;
using DesignPatternsInCSharp.Behavioral.Observer.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsInCSharp.Tests.Behavioral.Observer;

[TestClass]
public class ObservableObjectV3Tests
{
    [TestMethod]
    public void Subscribe_ObserverSubscribed_ReceivesUpdate()
    {
        //Arrange
        ObservableObjectV3 observableObjectV3 = new();
        IOwnObserver observer1 = new ConcreteObserver();
        Assert.AreEqual(0, observer1.ReceivedUpdates);

        //Act
        observableObjectV3.Subscribe(observer1);
        observableObjectV3.NotifySubscribers();

        IOwnObserver observer2 = new ConcreteObserver();
        Assert.AreEqual(0, observer2.ReceivedUpdates);
        observableObjectV3.Subscribe(observer2);

        //Assert
        Assert.AreEqual(1, observer1.ReceivedUpdates);
        Assert.AreEqual(0, observer2.ReceivedUpdates);
    }

    [TestMethod]
    public void Subscribe_SameObserverSubscribesMultipleTimes_ObserverReceivesOnlyOnce()
    {
        //Arrange
        ObservableObjectV3 observableObjectV3 = new();
        IOwnObserver observer1 = new ConcreteObserver();

        //Act
        observableObjectV3.Subscribe(observer1);
        observableObjectV3.Subscribe(observer1);

        //Assert
        observableObjectV3.NotifySubscribers();
        Assert.AreEqual(1, observer1.ReceivedUpdates);
    }
}
