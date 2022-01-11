using DesignPatternsInCSharp.Creational.Singleton;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DesignPatternsInCSharp.Tests.Creational.Singleton;

[TestClass]
public class SingletonServiceV3Tests
{
    [TestMethod]
    public void Instance_GetTwice_InstancesAreTheSame()
    {
        // Arrange
        var firstService = SingletonServiceV3.Instance;

        // Act
        var secondService = SingletonServiceV3.Instance;

        // Assert
        Assert.AreSame(firstService, secondService);
    }

    [TestMethod]
    public void Instance_ParallelInvoke_ServiceIsThreadSafe()
    {
        // Arrange
        SingletonServiceV3? firstService = null;
        SingletonServiceV3? secondService = null;

        // Act
        Parallel.Invoke(
            () => firstService = SingletonServiceV3.Instance,
            () => secondService = SingletonServiceV3.Instance
            );

        // Assert
        Assert.AreSame(firstService, secondService);
    }
}
