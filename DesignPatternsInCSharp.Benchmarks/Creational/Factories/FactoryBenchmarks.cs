using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using DesignPatternsInCSharp.Creational.Factories.Factory;
using DesignPatternsInCSharp.Creational.Factories.Factory.GenericTypeFactory;
using DesignPatternsInCSharp.Creational.Factories.Factory.Lazy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DesignPatternsInCSharp.Benchmarks.Creational.Factories;

[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[MemoryDiagnoser, DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportDiff: true)]
public class FactoryBenchmarks
{
    private readonly LoggerFactory _loggerFactory;
    private readonly ServiceProvider _serviceProviderForDiContainerFactory;
    private readonly ServiceProvider _serviceProviderForDiContainerFactoryV2;
    private readonly ServiceProvider _serviceProviderForGenericTypeFactory;
    private readonly ServiceProvider _serviceProviderForLazyFactory;

    public FactoryBenchmarks()
    {
        _loggerFactory = new LoggerFactory();

        // Naive Factory
        var services = new ServiceCollection()
             .AddLogging()
             .AddSingleton<DesignPatternsInCSharp.Creational.Factories.Factory.DiContainer.ProductFactory>();
        _serviceProviderForDiContainerFactory = services.BuildServiceProvider();

        // DI container Factory
        services = new ServiceCollection()
             .AddLogging()
             .AddSingleton<DesignPatternsInCSharp.Creational.Factories.Factory.DiContainer.ProductFactoryV2>();
        _serviceProviderForDiContainerFactoryV2 = services.BuildServiceProvider();

        // Generic Type Factory
        services = new ServiceCollection()
            .AddLogging()
            .AddTransient(typeof(IServiceFactory<>), typeof(ServiceFactory<>));
        _serviceProviderForGenericTypeFactory = services.BuildServiceProvider();

        // Lazy Factory
        services = new ServiceCollection()
            .AddLogging()
            .AddTransient<Product>()
            .AddTransient(typeof(ILazyFactory<>), typeof(LazyFactory<>));
        _serviceProviderForLazyFactory = services.BuildServiceProvider();
    }

    [BenchmarkCategory("WithoutParam")]
    [Benchmark(Baseline = true)]
    public void Naive()
    {
        var factroy = new DesignPatternsInCSharp.Creational.Factories.Factory.Naive.ProductFactory(_loggerFactory);
        _ = factroy.CreateProduct();
    }

    [BenchmarkCategory("WithParam")]
    [Benchmark(Baseline = true)]
    public void NaiveWithParam()
    {
        var factroy = new DesignPatternsInCSharp.Creational.Factories.Factory.Naive.ProductFactory(_loggerFactory);
        _ = factroy.CreateProductWithId(69);
    }

    [BenchmarkCategory("WithoutParam")]
    [Benchmark]
    public void DiContainer()
    {
        var factroy = _serviceProviderForDiContainerFactory.GetRequiredService<DesignPatternsInCSharp.Creational.Factories.Factory.DiContainer.ProductFactory>();
        _ = factroy.CreateProduct();
    }

    [BenchmarkCategory("WithParam")]
    [Benchmark]
    public void DiContainerWithParam()
    {
        var factroy = _serviceProviderForDiContainerFactory.GetRequiredService<DesignPatternsInCSharp.Creational.Factories.Factory.DiContainer.ProductFactory>();
        _ = factroy.CreateProductWithId(69);
    }

    [BenchmarkCategory("WithoutParam")]
    [Benchmark]
    public void DiContainerV2()
    {
        var factroy = _serviceProviderForDiContainerFactoryV2.GetRequiredService<DesignPatternsInCSharp.Creational.Factories.Factory.DiContainer.ProductFactoryV2>();
        _ = factroy.CreateProduct();
    }

    [BenchmarkCategory("WithParam")]
    [Benchmark]
    public void DiContainerWithParamV2()
    {
        var factroy = _serviceProviderForDiContainerFactoryV2.GetRequiredService<DesignPatternsInCSharp.Creational.Factories.Factory.DiContainer.ProductFactoryV2>();
        _ = factroy.CreateProductWithId(69);
    }

    [BenchmarkCategory("WithoutParam")]
    [Benchmark]
    public void GenericTypeFactory()
    {
        var factroy = _serviceProviderForGenericTypeFactory.GetRequiredService<IServiceFactory<Product>>();
        _ = factroy.CreateService();
    }

    [BenchmarkCategory("WithParam")]
    [Benchmark]
    public void GenericTypeFactoryWithParam()
    {
        var factroy = _serviceProviderForGenericTypeFactory.GetRequiredService<IServiceFactory<ProductWithId>>();
        _ = factroy.CreateServiceWithParam(69);
    }

    [BenchmarkCategory("WithoutParam")]
    [Benchmark]
    public void LazyFactory()
    {
        var factroy = _serviceProviderForLazyFactory.GetRequiredService<ILazyFactory<Product>>();
        _ = factroy.Value;
    }
}
