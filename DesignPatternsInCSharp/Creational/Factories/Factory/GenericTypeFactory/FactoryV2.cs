using Microsoft.Extensions.DependencyInjection;

namespace DesignPatternsInCSharp.Creational.Factories.Factory.GenericTypeFactory;

public class FactoryV2<T> : IFactoryV2<T> where T : class
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ObjectFactory _factory;
    private readonly ObjectFactory _factoryWithParam;

    public FactoryV2(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        _factory = ActivatorUtilities.CreateFactory(typeof(T), Type.EmptyTypes);
        _factoryWithParam = ActivatorUtilities.CreateFactory(typeof(T), new Type[] { typeof(int) });
    }

    public T CreateObject() => (T)_factory(_serviceProvider, null);

    public T CreateObjectWithId(int id) => (T)_factoryWithParam(_serviceProvider, new object[] { id });
}
