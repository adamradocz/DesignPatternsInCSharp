using DesignPatternsInCSharp.Creational.Singleton;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DesignPatternsInCSharp.Tests.Creational.Singleton;

[TestClass]
public class SingletonServiceV5Tests
{
    [TestMethod]
    public void Instance_GetTwice_InstancesAreTheSame()
    {
        // Arrange
        var firstService = SingletonServiceV5.Instance;

        // Act
        var secondService = SingletonServiceV5.Instance;

        // Assert
        Assert.AreSame(firstService, secondService);
    }

    [TestMethod]
    public void Instance_ParallelInvoke_ServiceIsThreadSafe()
    {
        // Arrange
        SingletonServiceV5? firstService = null;
        SingletonServiceV5? secondService = null;

        // Act
        Parallel.Invoke(
            () => firstService = SingletonServiceV5.Instance,
            () => secondService = SingletonServiceV5.Instance
            );

        // Assert
        Assert.AreSame(firstService, secondService);
    }
}
