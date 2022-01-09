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
            int firstCounter = 0;
            int secondCounter = 0;

            // Act
            Parallel.Invoke(
                () => firstCounter = SingletonService.Instance.Counter,
                () => secondCounter = SingletonService.Instance.Counter
                );

            // Assert
            Assert.AreEqual(1, firstCounter);
            Assert.AreEqual(1, secondCounter);
        }
    }
}