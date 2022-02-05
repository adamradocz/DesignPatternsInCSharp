using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsInCSharp.Tests.Creational.Factories.Factory.Naive;

[TestClass]
public class ProductFactoryTests
{
    [TestMethod]
    public void CreateProduct_WithoutId_GetProduct()
    {
        // Arrange
        var loggerFactory = new LoggerFactory();
        var factroy = new DesignPatternsInCSharp.Creational.Factories.Factory.Naive.ProductFactory(loggerFactory);

        // Act
        var product = factroy.CreateProduct();

        // Assert
        Assert.AreEqual("Product", product.Operation());
    }

    [TestMethod]
    public void CreateProduct_PassId_GetProductWithId()
    {
        // Arrange
        int id = 69;
        var loggerFactory = new LoggerFactory();
        var factroy = new DesignPatternsInCSharp.Creational.Factories.Factory.Naive.ProductFactory(loggerFactory);

        // Act
        var product = factroy.CreateProductWithId(id);

        // Assert
        Assert.AreEqual(id, product.Id);
        Assert.AreEqual("ProductWithId", product.Operation());
    }
}
