using DesignPatternsInCSharp.Behavioral.Strategy.Conceptual;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsInCSharp.Tests.Behavioral.Strategy;

[TestClass]
public class ContextTests
{
    [TestMethod]
    public void Request_DefaultStrategyIsUsed_ReturnsConcreteStrategyAName()
    {
        // Arrange
        var context = new Context();

        // Act
        string concreteStrategyName = context.Request();

        // Assert
        Assert.AreEqual(nameof(ConcreteStrategyA), concreteStrategyName);
    }

    [TestMethod]
    public void Request_ConcretetSrategyBIsSetted_ReturnsConcreteStrategyBName()
    {
        // Arrange
        var context = new Context
        {
            Strategy = new ConcreteStrategyB()
        };

        // Act
        string concreteStrategyName = context.Request();

        // Assert
        Assert.AreEqual(nameof(ConcreteStrategyB), concreteStrategyName);
    }

    [TestMethod]
    public void Request_ConcretetSrategyBThenCIsSetted_ReturnsConcreteStrategyCName()
    {
        // Arrange
        var context = new Context
        {
            Strategy = new ConcreteStrategyB()
        };

        // Act
        string concreteStrategyName = context.Request();
        Assert.AreEqual(nameof(ConcreteStrategyB), concreteStrategyName);

        context.Strategy = new ConcreteStrategyC();
        concreteStrategyName = context.Request();

        // Assert
        Assert.AreEqual(nameof(ConcreteStrategyC), concreteStrategyName);
    }
}
