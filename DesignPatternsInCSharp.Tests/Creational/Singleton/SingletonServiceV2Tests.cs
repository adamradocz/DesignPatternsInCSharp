using DesignPatternsInCSharp.Creational.Singleton;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DesignPatternsInCSharp.Tests.Creational.Singleton;

[TestClass]
public class SingletonServiceV2Tests
{
    [TestMethod]
    public void Instance_GetTwice_InstancesAreTheSame()
    {
        // Arrange
        var firstService = SingletonServiceV2.Instance;

        // Act
        var secondService = SingletonServiceV2.Instance;

        // Assert
        Assert.AreSame(firstService, secondService);
    }

    [TestMethod]
    public void Instance_ParallelInvoke_ServiceIsThreadSafe()
    {
        // Arrange
        SingletonServiceV2? firstService = null;
        SingletonServiceV2? secondService = null;

        // Act
        Parallel.Invoke(
            () => firstService = SingletonServiceV2.Instance,
            () => secondService = SingletonServiceV2.Instance
            );

        // Assert
        Assert.AreSame(firstService, secondService);
    }
}
