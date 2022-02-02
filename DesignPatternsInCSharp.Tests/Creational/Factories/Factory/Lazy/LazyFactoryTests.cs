using DesignPatternsInCSharp.Creational.Factories.Factory;
using DesignPatternsInCSharp.Creational.Factories.Factory.Lazy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsInCSharp.Tests.Creational.Factories.Factory.Lazy;

[TestClass]
public class LazyFactoryTests
{
    [TestMethod]
    public void CreateProduct_WithoutId_GetProduct()
    {
        // Arrange
        var services = new ServiceCollection()
            .AddLogging()
            .AddTransient<Product>()
            .AddTransient(typeof(ILazyFactory<>), typeof(LazyFactory<>));

        var serviceProvider = services.BuildServiceProvider();
        var factroy = serviceProvider.GetRequiredService<ILazyFactory<Product>>();

        // Act
        var product = factroy.Value;

        // Assert
        Assert.AreEqual("Product", product.Operation());
    }
}
