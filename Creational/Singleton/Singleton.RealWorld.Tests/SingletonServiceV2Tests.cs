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
            int firstCounter = 0;
            int secondCounter = 0;

            // Act
            Parallel.Invoke(
                () => firstCounter = _serviceProvider.GetRequiredService<SingletonServiceV2>().Counter,
                () => secondCounter = _serviceProvider.GetRequiredService<SingletonServiceV2>().Counter
                );

            // Assert
            Assert.AreEqual(1, firstCounter);
            Assert.AreEqual(1, secondCounter);
        }
    }
}