using Microsoft.Extensions.DependencyInjection;

namespace DesignPatternsInCSharp.Creational.Factories.Factory.GenericTypeFactory;

public class Factory<T> : IFactory<T> where T : class
{
    private readonly IServiceProvider _serviceProvider;

    public Factory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }

    public T CreateObject() => ActivatorUtilities.CreateInstance<T>(_serviceProvider);

    public T CreateObjectWithParam(params object[] args) => ActivatorUtilities.CreateInstance<T>(_serviceProvider, args);
}
