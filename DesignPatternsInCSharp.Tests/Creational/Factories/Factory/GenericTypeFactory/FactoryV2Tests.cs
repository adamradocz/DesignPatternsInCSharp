using DesignPatternsInCSharp.Creational.Factories.Factory;
using DesignPatternsInCSharp.Creational.Factories.Factory.GenericTypeFactory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsInCSharp.Tests.Creational.Factories.Factory.GenericTypeFactory;

[TestClass]
public class FactoryV2Tests
{
    [TestMethod]
    public void CreateService_DependencyHasntAdded_GetProduct()
    {
        // Arrange
        var services = new ServiceCollection()
            .AddLogging()
            .AddSingleton(typeof(IFactoryV2<>), typeof(FactoryV2<>));

        var serviceProvider = services.BuildServiceProvider();
        var factroy = serviceProvider.GetRequiredService<IFactoryV2<Product>>();

        // Act
        var product = factroy.CreateObject();

        // Assert
        Assert.AreEqual("Product", product.Operation());
    }

    [TestMethod]
    public void CreateService_DependencyHasntAdded_GetProductWithId()
    {
        // Arrange
        int id = 69;
        var services = new ServiceCollection()
            .AddLogging()
            .AddSingleton(typeof(IFactoryV2<>), typeof(FactoryV2<>));

        var serviceProvider = services.BuildServiceProvider();
        var factroy = serviceProvider.GetRequiredService<IFactoryV2<ProductWithId>>();

        // Act
        var product = factroy.CreateObjectWithId(id);

        // Assert
        Assert.AreEqual(id, product.Id);
        Assert.AreEqual("ProductWithId", product.Operation());
    }
}
