using Microsoft.Extensions.DependencyInjection;

namespace DesignPatternsInCSharp.Creational.Factories.Factory.DiContainer;

public class ProductFactoryV2
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ObjectFactory _factory;
    private readonly ObjectFactory _factoryWithId;

    public ProductFactoryV2(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        _factory = ActivatorUtilities.CreateFactory(typeof(Product), Type.EmptyTypes);
        _factoryWithId = ActivatorUtilities.CreateFactory(typeof(ProductWithId), new Type[] { typeof(int) });
    }
    public Product CreateProduct() => (Product)_factory(_serviceProvider, null);

    public ProductWithId CreateProductWithId(int id) => (ProductWithId)_factoryWithId(_serviceProvider, new object[] { id });
}
