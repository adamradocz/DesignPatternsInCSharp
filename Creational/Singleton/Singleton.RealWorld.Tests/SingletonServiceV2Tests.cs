using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Singleton.RealWorld.Tests
{
    [TestClass]
    public class SingletonServiceV2Tests
    {
        private readonly ServiceProvider _serviceProvider;

        public SingletonServiceV2Tests()
        {
            _serviceProvider = new ServiceCollection()
                .AddSingleton<SingletonServiceV2>()
                .BuildServiceProvider();
        }

        [TestMethod]
        public void Instance_GetTwice_InstancesAreTheSame()
        {
            // Arrange
            var firstService = _serviceProvider.GetRequiredService<SingletonServiceV2>();

            // Act
            var secondService = _serviceProvider.GetRequiredService<SingletonServiceV2>();

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
                () => firstService = _serviceProvider.GetRequiredService<SingletonServiceV2>(),
                () => secondService = _serviceProvider.GetRequiredService<SingletonServiceV2>()
                );

            // Assert
            Assert.AreSame(firstService, secondService);
            Assert.AreEqual(1, firstService?.Counter);
            Assert.AreEqual(1, secondService?.Counter);
        }
    }
}