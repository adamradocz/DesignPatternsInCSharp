using DesignPatternsInCSharp.Creational.Singleton;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DesignPatternsInCSharp.Tests.Creational.Singleton;

[TestClass]
public class SingletonServiceV1Tests
{
    [TestMethod]
    public void Instance_GetTwice_InstancesAreTheSame()
    {
        // Arrange
        var firstService = SingletonServiceV1.Instance;

        // Act
        var secondService = SingletonServiceV1.Instance;

        // Assert
        Assert.AreSame(firstService, secondService);
    }

    [TestMethod]
    public void Instance_ParallelInvoke_ServiceIsNotThreadSafe()
    {
        // Arrange
        SingletonServiceV1? firstService = null;
        SingletonServiceV1? secondService = null;

        // Act
        Parallel.Invoke(
            () => firstService = SingletonServiceV1.Instance,
            () => secondService = SingletonServiceV1.Instance
            );

        // Assert
        Assert.AreNotSame(firstService, secondService);
    }
}
