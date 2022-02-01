using DesignPatternsInCSharp.Creational.Factories.InnerFactory.Conceptual;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsInCSharp.Tests.Creational.Factories.InnerFactory;

[TestClass]
public class ConceptualTests
{
    [TestMethod]
    public void Factory_CreateX_GetX()
    {
        // Arrange
        var product = Product.Factory.Create();

        // Assert
        Assert.AreEqual("Product", product.Operation());
    }
}
