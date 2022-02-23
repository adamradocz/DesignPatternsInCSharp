using DesignPatternsInCSharp.Structural.Flyweight.Naive;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsInCSharp.Tests.Structural.Flyweight;

[TestClass]
public class FlyweightTests
{
    [TestMethod]
    public void ConcreteTree_MultipleTreesWithSameType_CacheUsed()
    {
        //Arrange
        var services = new ServiceCollection()
            .AddSingleton<TreeTypeFactory>();

        var serviceProvider = services.BuildServiceProvider();
        var treeTypeFactory = serviceProvider.GetRequiredService<TreeTypeFactory>();

        //Act
        var concreteTree1 = new ConcreteTree(10, 1, treeTypeFactory.GetTreeType("Oak"));

        //Assert
        Assert.AreEqual("Oak", concreteTree1.TreeType.Name);
        Assert.AreEqual("Normal", concreteTree1.TreeType.Hardness);
        Assert.AreEqual(1,treeTypeFactory.CurrentCacheSize);

        //Act
        var concreteTree2 = new ConcreteTree(10, 1, treeTypeFactory.GetTreeType("Oak"));

        //Assert
        Assert.AreEqual("Oak", concreteTree2.TreeType.Name);
        Assert.AreEqual("Normal", concreteTree2.TreeType.Hardness);
        Assert.AreEqual(1, treeTypeFactory.CurrentCacheSize);
    }

    [TestMethod]
    public void ConcreteTree_MultipleTreesWithDifferentType_MultipleTypesCreated()
    {
        //Arrange
        var services = new ServiceCollection()
            .AddSingleton<TreeTypeFactory>();

        var serviceProvider = services.BuildServiceProvider();
        var treeTypeFactory = serviceProvider.GetRequiredService<TreeTypeFactory>();

        //Act
        var concreteTree1 = new ConcreteTree(10, 1, treeTypeFactory.GetTreeType("Oak"));

        //Assert
        Assert.AreEqual("Oak", concreteTree1.TreeType.Name);
        Assert.AreEqual("Normal", concreteTree1.TreeType.Hardness);
        Assert.AreEqual(1, treeTypeFactory.CurrentCacheSize);

        //Act
        var concreteTree2 = new ConcreteTree(10, 1, treeTypeFactory.GetTreeType("Pine", "Hard"));

        //Assert
        Assert.AreEqual("Pine", concreteTree2.TreeType.Name);
        Assert.AreEqual("Hard", concreteTree2.TreeType.Hardness);
        Assert.AreEqual(2, treeTypeFactory.CurrentCacheSize);

        //Act
        var concreteTree3 = new ConcreteTree(10, 1, treeTypeFactory.GetTreeType("Oak"));

        //Assert
        Assert.AreEqual("Oak", concreteTree3.TreeType.Name);
        Assert.AreEqual("Normal", concreteTree3.TreeType.Hardness);
        Assert.AreEqual(2, treeTypeFactory.CurrentCacheSize);
    }
}
