using Microsoft.Extensions.DependencyInjection;

namespace DesignPatternsInCSharp.Creational.Factories.Factory.DiContainer;

public class ProductFactory
{
    private readonly IServiceProvider _serviceProvider;

    public ProductFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }

    public Product CreateProduct() => ActivatorUtilities.CreateInstance<Product>(_serviceProvider);

    public ProductWithId CreateProductWithId(int id) => ActivatorUtilities.CreateInstance<ProductWithId>(_serviceProvider, id);
}
