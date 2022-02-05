using DesignPatternsInCSharp.Behavioral.State.Conceptual;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsInCSharp.Tests.Behavioral.State.Conceptual;

[TestClass]
public class ContextTests
{
    [TestMethod]
    public void Request_ConcrateStateAPassed_TransitionToStateB()
    {
        // Arrange
        var context = new Context(new ConcreteStateA());

        // Act
        context.Request();

        // Assert
        Assert.AreEqual(nameof(ConcreteStateB), context.State.GetType().Name);
    }

    [TestMethod]
    public void Request_ConcrateStateBPassed_TransitionToStateC()
    {
        // Arrange
        var context = new Context(new ConcreteStateB());

        // Act
        context.Request();

        // Assert
        Assert.AreEqual(nameof(ConcreteStateC), context.State.GetType().Name);
    }

    [TestMethod]
    public void Request_ConcrateStateCPassed_TransitionToStateA()
    {
        // Arrange
        var context = new Context(new ConcreteStateC());

        // Act
        context.Request();

        // Assert
        Assert.AreEqual(nameof(ConcreteStateA), context.State.GetType().Name);
    }

    [TestMethod]
    public void Request_ConcrateStateAPassedAndRequestCalledTwice_TransitionToStateC()
    {
        // Arrange
        var context = new Context(new ConcreteStateA());

        // Act
        context.Request();
        context.Request();

        // Assert
        Assert.AreEqual(nameof(ConcreteStateC), context.State.GetType().Name);
    }
}
