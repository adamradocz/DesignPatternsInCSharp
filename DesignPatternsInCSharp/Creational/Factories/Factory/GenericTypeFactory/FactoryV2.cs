using Microsoft.Extensions.DependencyInjection;

namespace DesignPatternsInCSharp.Creational.Factories.Factory.GenericTypeFactory;

// Two generic types cannot be cached in the same time, that's the reason the separate the CreateObject and the CreateObjectWithId methods.
public class FactoryV2<T> : IFactoryV2<T> where T : class
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ObjectFactory _factory;

    public FactoryV2(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        _factory = ActivatorUtilities.CreateFactory(typeof(T), Type.EmptyTypes);
    }

    public T CreateObject() => (T)_factory(_serviceProvider, null);
}
