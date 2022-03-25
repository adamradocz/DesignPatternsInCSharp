using DesignPatternsInCSharp.Creational.Factories.Factory;
using DesignPatternsInCSharp.Creational.Factories.Factory.GenericTypeFactory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsInCSharp.Tests.Creational.Factories.Factory.GenericTypeFactory;

[TestClass]
public class FactoryTests
{

    [TestMethod]
    public void CreateService_DependencyHasntAdded_GetProduct()
    {
        // Arrange
        var services = new ServiceCollection()
            .AddLogging()
            .AddSingleton(typeof(IFactory<>), typeof(Factory<>));

        var serviceProvider = services.BuildServiceProvider();
        var factroy = serviceProvider.GetRequiredService<IFactory<Product>>();

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
            .AddSingleton(typeof(IFactory<>), typeof(Factory<>));

        var serviceProvider = services.BuildServiceProvider();
        var factroy = serviceProvider.GetRequiredService<IFactory<ProductWithId>>();

        // Act
        var product = factroy.CreateObjectWithParam(id);

        // Assert
        Assert.AreEqual(id, product.Id);
        Assert.AreEqual("ProductWithId", product.Operation());
    }
}
