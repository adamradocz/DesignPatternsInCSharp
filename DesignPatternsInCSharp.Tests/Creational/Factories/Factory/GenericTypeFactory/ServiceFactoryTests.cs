using DesignPatternsInCSharp.Creational.Factories.Factory;
using DesignPatternsInCSharp.Creational.Factories.Factory.GenericTypeFactory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsInCSharp.Tests.Creational.Factories.Factory.GenericTypeFactory;

[TestClass]
public class ServiceFactoryTests
{
    [TestMethod]
    public void CreateService_DependencyAdded_GetProduct()
    {
        // Arrange
        var services = new ServiceCollection()
            .AddLogging()
            .AddTransient<Product>()
            .AddTransient(typeof(IServiceFactory<>), typeof(ServiceFactory<>));

        var serviceProvider = services.BuildServiceProvider();
        var factroy = serviceProvider.GetRequiredService<IServiceFactory<Product>>();

        // Act
        var product = factroy.CreateService();

        // Assert
        Assert.AreEqual("Product", product.Operation());
    }

    [TestMethod]
    public void CreateService_DependencyHasntAdded_GetProduct()
    {
        // Arrange
        var services = new ServiceCollection()
            .AddLogging()
            .AddTransient(typeof(IServiceFactory<>), typeof(ServiceFactory<>));

        var serviceProvider = services.BuildServiceProvider();
        var factroy = serviceProvider.GetRequiredService<IServiceFactory<Product>>();

        // Act
        var product = factroy.CreateService();

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
            .AddTransient(typeof(IServiceFactory<>), typeof(ServiceFactory<>));

        var serviceProvider = services.BuildServiceProvider();
        var factroy = serviceProvider.GetRequiredService<IServiceFactory<ProductWithId>>();

        // Act
        var product = factroy.CreateServiceWithParam(id);

        // Assert
        Assert.AreEqual(id, product.Id);
        Assert.AreEqual("ProductWithId", product.Operation());
    }
}
