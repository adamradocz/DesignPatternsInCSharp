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
        ObservableObjectV3 observableObjectV5 = new();
        ICustomObserver observer1 = new ConcreteObserver();
        Assert.AreEqual(0, observer1.ReceivedUpdates);

        //Act
        observableObjectV5.Subscribe(observer1.Update);
        observableObjectV5.NotifyObservers();

        ICustomObserver observer2 = new ConcreteObserver();
        Assert.AreEqual(0, observer2.ReceivedUpdates);
        observableObjectV5.Subscribe(observer2.Update);

        //Assert
        Assert.AreEqual(1, observer1.ReceivedUpdates);
        Assert.AreEqual(0, observer2.ReceivedUpdates);
    }

    [TestMethod]
    public void Subscribe_SameObserverSubscribesMultipleTimes_ObserverReceivesMultipleTimes()
    {
        //Arrange
        ObservableObjectV3 observableObjectV5 = new();
        ICustomObserver observer1 = new ConcreteObserver();

        //Act
        observableObjectV5.Subscribe(observer1.Update);
        observableObjectV5.Subscribe(observer1.Update);

        //Assert
        observableObjectV5.NotifyObservers();
        Assert.AreEqual(2, observer1.ReceivedUpdates);
    }
}
