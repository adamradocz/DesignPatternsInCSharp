using Microsoft.Extensions.DependencyInjection;

namespace DesignPatternsInCSharp.Creational.Factories.Factory.Lazy;

public class LazyFactory<T> : ILazyFactory<T>
{
    private readonly Lazy<T> _lazy;

    public LazyFactory(IServiceProvider serviceProvider)
    {
        if (serviceProvider is null)
        {
            throw new ArgumentNullException(nameof(serviceProvider));
        }

        _lazy = new Lazy<T>(() => serviceProvider.GetRequiredService<T>());
    }

    public T Value => _lazy.Value;
}

