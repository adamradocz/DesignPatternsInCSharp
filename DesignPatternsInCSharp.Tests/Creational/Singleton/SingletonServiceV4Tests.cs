using DesignPatternsInCSharp.Creational.Singleton;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DesignPatternsInCSharp.Tests.Creational.Singleton;

[TestClass]
public class SingletonServiceV4Tests
{
    [TestMethod]
    public void Instance_GetTwice_InstancesAreTheSame()
    {
        // Arrange
        var firstService = SingletonServiceV4.Instance;

        // Act
        var secondService = SingletonServiceV4.Instance;

        // Assert
        Assert.AreSame(firstService, secondService);
    }

    [TestMethod]
    public void Instance_ParallelInvoke_ServiceIsThreadSafe()
    {
        // Arrange
        SingletonServiceV4? firstService = null;
        SingletonServiceV4? secondService = null;

        // Act
        Parallel.Invoke(
            () => firstService = SingletonServiceV4.Instance,
            () => secondService = SingletonServiceV4.Instance
            );

        // Assert
        Assert.AreSame(firstService, secondService);
    }
}
