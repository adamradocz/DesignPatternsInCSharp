using Microsoft.Extensions.Logging;

namespace DesignPatternsInCSharp.Creational.Factories.Factory;

public class Product
{
    private readonly ILogger<Product> _logger;

    public Product(ILogger<Product> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public string Operation() => nameof(Product);
}
