using DesignPatternsInCSharp.Behavioral.Observer;
using DesignPatternsInCSharp.Behavioral.Observer.Implementations;
using DesignPatternsInCSharp.Behavioral.Observer.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsInCSharp.Tests.Behavioral.Observer;

[TestClass]
public class ObservableObjectV1Tests
{
    [TestMethod]
    public void Subscribe_ObserverSubscribed_ReceivesUpdate()
    {
        //Arrange
        ObservableObjectV1 observableObjectV1 = new();
        ICustomObserver observer1 = new ConcreteObserver();
        Assert.AreEqual(0, observer1.ReceivedUpdates);

        //Act
        observableObjectV1.Subscribe(observer1);
        observableObjectV1.NotifySubscribers();

        ICustomObserver observer2 = new ConcreteObserver();
        Assert.AreEqual(0, observer2.ReceivedUpdates);
        observableObjectV1.Subscribe(observer2);

        //Assert
        Assert.AreEqual(1, observer1.ReceivedUpdates);
        Assert.AreEqual(0, observer2.ReceivedUpdates);
    }

    [TestMethod]
    public void Subscribe_SameObserverSubscribesMultipleTimes_ObserverReceivesMultipleTimes()
    {
        //Arrange
        ObservableObjectV1 observableObjectV1 = new();
        ICustomObserver observer1 = new ConcreteObserver();

        //Act
        observableObjectV1.Subscribe(observer1);
        observableObjectV1.Subscribe(observer1);
        Assert.AreNotEqual(1, observableObjectV1.NumberOfSubscribers);

        //Assert
        observableObjectV1.NotifySubscribers();
        Assert.AreEqual(2, observer1.ReceivedUpdates);
    }
}
