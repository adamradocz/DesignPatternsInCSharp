using DesignPatternsInCSharp.Creational.Factories.FactoryMethod.Conceptual;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsInCSharp.Tests.Creational.Factories.FactoryMethod;

[TestClass]
public class ConceptualTests
{
    [TestMethod]
    public void Factory_CreateProductX_GetProductX()
    {
        // Arrange
        var factroy = new ConcreteFactory();

        // Act
        var productA = factroy.CreateProduct('A');
        var productB = factroy.CreateProduct('B');

        // Assert
        Assert.AreEqual("ProductA", productA.Operation());
        Assert.AreEqual("ProductB", productB.Operation());
    }
}
