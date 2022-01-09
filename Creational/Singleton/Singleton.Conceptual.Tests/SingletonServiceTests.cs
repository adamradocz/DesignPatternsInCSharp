using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Singleton.Conceptual.Tests;

[TestClass]
public class SingletonServiceTests
{
    [TestMethod]
    public void Instance_GetTwice_InstancesAreTheSame()
    {
        // Arrange
        var firstService = SingletonService.Instance;

        // Act
        var secondService = SingletonService.Instance;

        // Assert
        Assert.AreSame(firstService, secondService);
    }
}
