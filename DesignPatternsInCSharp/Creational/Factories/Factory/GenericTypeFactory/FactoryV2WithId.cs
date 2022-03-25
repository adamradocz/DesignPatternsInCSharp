using Microsoft.Extensions.DependencyInjection;

namespace DesignPatternsInCSharp.Creational.Factories.Factory.GenericTypeFactory;

// Two generic types cannot be cached in the same time, that's the reason the separate the CreateObject and the CreateObjectWithId methods.
public class FactoryV2WithId<T> : IFactoryV2WithId<T> where T : class
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ObjectFactory _factoryWithId;

    public FactoryV2WithId(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        _factoryWithId = ActivatorUtilities.CreateFactory(typeof(T), new Type[] { typeof(int) });
    }

    public T CreateObjectWithId(int id) => (T)_factoryWithId(_serviceProvider, new object[] { id });
}
