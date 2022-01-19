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
        ObservableObjectV4 observableObjectV4 = new();
        IOwnObserver observer1 = new ConcreteObserver();
        Assert.AreEqual(0, observer1.ReceivedUpdates);

        //Act
        observableObjectV4.Subscribe(observer1);
        observableObjectV4.NotifySubscribers();

        IOwnObserver observer2 = new ConcreteObserver();
        Assert.AreEqual(0, observer2.ReceivedUpdates);
        observableObjectV4.Subscribe(observer2);

        //Assert
        Assert.AreEqual(1, observer1.ReceivedUpdates);
        Assert.AreEqual(0, observer2.ReceivedUpdates);
    }

    [TestMethod]
    public void Subscribe_SameObserverSubscribesMultipleTimes_ObserverReceivesMultipleTimes()
    {
        //Arrange
        ObservableObjectV4 observableObjectV4 = new();
        IOwnObserver observer1 = new ConcreteObserver();

        //Act
        observableObjectV4.Subscribe(observer1);
        observableObjectV4.Subscribe(observer1);

        //Assert
        observableObjectV4.NotifySubscribers();
        Assert.AreEqual(2, observer1.ReceivedUpdates);
    }
}
