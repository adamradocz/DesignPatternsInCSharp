using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Singleton.RealWorld.Tests
{
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

        [TestMethod]
        public void Instance_ParallelInvoke_ServiceIsThreadSafe()
        {
            // Arrange
            SingletonService? firstService = null;
            SingletonService? secondService = null;

            // Act
            Parallel.Invoke(
                () => firstService = SingletonService.Instance,
                () => secondService = SingletonService.Instance
                );

            // Assert
            Assert.AreSame(firstService, secondService);
            Assert.AreEqual(1, firstService?.Counter);
            Assert.AreEqual(1, secondService?.Counter);
        }
    }
}