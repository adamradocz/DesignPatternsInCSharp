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
    private readonly ServiceProvider _serviceProvider;
    private readonly ServiceProvider _serviceProviderForLazyFactory;

    public FactoryBenchmarks()
    {
        _loggerFactory = new LoggerFactory();

        // DI container Factory
        var services = new ServiceCollection()
             .AddLogging()
             .AddSingleton<DesignPatternsInCSharp.Creational.Factories.Factory.DiContainer.ProductFactory>()
             .AddSingleton<DesignPatternsInCSharp.Creational.Factories.Factory.DiContainer.ProductFactoryV2>()
             .AddSingleton(typeof(IFactory<>), typeof(Factory<>))
             .AddSingleton(typeof(IFactoryV2<>), typeof(FactoryV2<>))
             .AddSingleton(typeof(IFactoryV2WithId<>), typeof(FactoryV2WithId<>));
        _serviceProvider = services.BuildServiceProvider();

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
        var factroy = _serviceProvider.GetRequiredService<DesignPatternsInCSharp.Creational.Factories.Factory.DiContainer.ProductFactory>();
        _ = factroy.CreateProduct();
    }

    [BenchmarkCategory("WithParam")]
    [Benchmark]
    public void DiContainerWithParam()
    {
        var factroy = _serviceProvider.GetRequiredService<DesignPatternsInCSharp.Creational.Factories.Factory.DiContainer.ProductFactory>();
        _ = factroy.CreateProductWithId(69);
    }

    [BenchmarkCategory("WithoutParam")]
    [Benchmark]
    public void DiContainerV2()
    {
        var factroy = _serviceProvider.GetRequiredService<DesignPatternsInCSharp.Creational.Factories.Factory.DiContainer.ProductFactoryV2>();
        _ = factroy.CreateProduct();
    }

    [BenchmarkCategory("WithParam")]
    [Benchmark]
    public void DiContainerWithParamV2()
    {
        var factroy = _serviceProvider.GetRequiredService<DesignPatternsInCSharp.Creational.Factories.Factory.DiContainer.ProductFactoryV2>();
        _ = factroy.CreateProductWithId(69);
    }

    [BenchmarkCategory("WithoutParam")]
    [Benchmark]
    public void GenericTypeFactory()
    {
        var factroy = _serviceProvider.GetRequiredService<IFactory<Product>>();
        _ = factroy.CreateObject();
    }

    [BenchmarkCategory("WithParam")]
    [Benchmark]
    public void GenericTypeFactoryWithParam()
    {
        var factroy = _serviceProvider.GetRequiredService<IFactory<ProductWithId>>();
        _ = factroy.CreateObjectWithParam(69);
    }

    [BenchmarkCategory("WithoutParam")]
    [Benchmark]
    public void GenericTypeFactoryV2()
    {
        var factroy = _serviceProvider.GetRequiredService<IFactoryV2<Product>>();
        _ = factroy.CreateObject();
    }

    [BenchmarkCategory("WithParam")]
    [Benchmark]
    public void GenericTypeFactoryV2WithParam()
    {
        var factroy = _serviceProvider.GetRequiredService<IFactoryV2WithId<ProductWithId>>();
        _ = factroy.CreateObjectWithId(69);
    }

    [BenchmarkCategory("WithoutParam")]
    [Benchmark]
    public void LazyFactory()
    {
        var factroy = _serviceProviderForLazyFactory.GetRequiredService<ILazyFactory<Product>>();
        _ = factroy.Value;
    }
}
