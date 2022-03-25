using Microsoft.Extensions.Logging;

namespace DesignPatternsInCSharp.Creational.Factories.Factory.Naive;

public class ProductFactory
{
    private readonly ILogger<Product> _logger;
    private readonly ILogger<ProductWithId> _loggerWithId;

    public ProductFactory(LoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<Product>();
        _loggerWithId = loggerFactory.CreateLogger<ProductWithId>();
    }

    public Product CreateProduct() => new(_logger);

    public ProductWithId CreateProductWithId(int id) => new(_loggerWithId, id);
}
