using Microsoft.Extensions.DependencyInjection;
using Singleton.RealWorld;

// Lazy and thread safe singleton service.
var singletonService = SingletonService.Instance;

// The service is not singleton, but it is used as one, thanks to the Dependency Injection Container.
var serviceProvider = new ServiceCollection()
                .AddSingleton<SingletonServiceV2>()
                .BuildServiceProvider();
var singletonServiceV2 = serviceProvider.GetRequiredService<SingletonServiceV2>();