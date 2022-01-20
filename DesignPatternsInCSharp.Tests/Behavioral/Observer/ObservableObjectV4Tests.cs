using DesignPatternsInCSharp.Behavioral.Observer;
using DesignPatternsInCSharp.Behavioral.Observer.Implementations;
using DesignPatternsInCSharp.Behavioral.Observer.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsInCSharp.Tests.Behavioral.Observer;

[TestClass]
public class ObservableObjectV4Tests
{
    [TestMethod]
    public void Subscribe_ObserverSubscribed_ReceivesUpdate()
    {
        //Arrange
        ObservableObjectV4 observableObjectV6 = new();
        ICustomObserver observer1 = new ConcreteObserver();
        Assert.AreEqual(0, observer1.ReceivedUpdates);

        //Act
        using var disposable = observableObjectV6.Subscribe(observer1);
        observableObjectV6.NotifySubscribers();

        ICustomObserver observer2 = new ConcreteObserver();
        Assert.AreEqual(0, observer2.ReceivedUpdates);
        using var disposable2 = observableObjectV6.Subscribe(observer2);

        //Assert
        Assert.AreEqual(1, observer1.ReceivedUpdates);
        Assert.AreEqual(0, observer2.ReceivedUpdates);
    }

    [TestMethod]
    public void Subscribe_SameObserverSubscribesMultipleTimes_ObserverReceivesMultipleTimes()
    {
        //Arrange
        ObservableObjectV4 observableObjectV6 = new();
        ICustomObserver observer1 = new ConcreteObserver();

        //Act
        using var disposable = observableObjectV6.Subscribe(observer1);
        _ = observableObjectV6.Subscribe(observer1);

        //Assert
        observableObjectV6.NotifySubscribers();
        Assert.AreEqual(2, observer1.ReceivedUpdates);
    }
}
