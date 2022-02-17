using DesignPatternsInCSharp.Structural.Adapter.Conceptual;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsInCSharp.Tests.Structural.Adapter;

[TestClass]
public class ConceptualTests
{
    [TestMethod]
    public void AdapteeConvertedToTarget()
    {
        // Arrange
        var adaptee = new Adaptee();
        ITarget target = new DesignPatternsInCSharp.Structural.Adapter.Conceptual.Adapter(adaptee);

        // Act
        string specificResult = adaptee.SpecificRequest();
        byte[] result = target.Request();

        // Assert
        Assert.AreEqual(specificResult, System.Text.Encoding.UTF8.GetString(result));
    }
}
