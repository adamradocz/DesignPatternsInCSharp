using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsInCSharp.Tests.Creational.Factories.Factory.DiContainer;

[TestClass]
public class ProductFactoryV2Tests
{
    [TestMethod]
    public void CreateProduct_WithoutId_GetProduct()
    {
        // Arrange
        var services = new ServiceCollection()
            .AddLogging()
            .AddSingleton<DesignPatternsInCSharp.Creational.Factories.Factory.DiContainer.ProductFactoryV2>();

        var serviceProvider = services.BuildServiceProvider();
        var factroy = serviceProvider.GetRequiredService<DesignPatternsInCSharp.Creational.Factories.Factory.DiContainer.ProductFactoryV2>();

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
        var services = new ServiceCollection()
            .AddLogging()
            .AddSingleton<DesignPatternsInCSharp.Creational.Factories.Factory.DiContainer.ProductFactoryV2>();

        var serviceProvider = services.BuildServiceProvider();
        var factroy = serviceProvider.GetRequiredService<DesignPatternsInCSharp.Creational.Factories.Factory.DiContainer.ProductFactoryV2>();

        // Act
        var product = factroy.CreateProductWithId(id);

        // Assert
        Assert.AreEqual(id, product.Id);
        Assert.AreEqual("ProductWithId", product.Operation());
    }
}
