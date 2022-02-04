using Microsoft.Extensions.DependencyInjection;

namespace DesignPatternsInCSharp.Creational.Factories.Factory.GenericTypeFactory;

public class ServiceFactory<TService> : IServiceFactory<TService>
{
    private readonly IServiceProvider _serviceProvider;

    public ServiceFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }

    public TService CreateService() => (TService)_serviceProvider.GetService(typeof(TService)) ?? ActivatorUtilities.CreateInstance<TService>(_serviceProvider);

    public TService CreateServiceWithParam(params object[] args) => ActivatorUtilities.CreateInstance<TService>(_serviceProvider, args);
}
