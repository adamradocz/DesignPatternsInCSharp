using DesignPatternsInCSharp.Creational.Singleton;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DesignPatternsInCSharp.Tests.Creational.Singleton;

[TestClass]
public class SingletonServiceV6Tests
{
    [TestMethod]
    public void Instance_GetTwice_InstancesAreTheSame()
    {
        // Arrange
        var firstService = SingletonServiceV6.Instance;

        // Act
        var secondService = SingletonServiceV6.Instance;

        // Assert
        Assert.AreSame(firstService, secondService);
    }

    [TestMethod]
    public void Instance_ParallelInvoke_ServiceIsThreadSafe()
    {
        // Arrange
        SingletonServiceV6? firstService = null;
        SingletonServiceV6? secondService = null;

        // Act
        Parallel.Invoke(
            () => firstService = SingletonServiceV6.Instance,
            () => secondService = SingletonServiceV6.Instance
            );

        // Assert
        Assert.AreSame(firstService, secondService);
    }
}
