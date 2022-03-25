# Factory Pattern

Definition: Creates objects without exposing the instantiation logic to the client.

When to use: Client just need a class and does not care about which concrete implementation it is getting.

Versions:

- Naive: The most basic implementation.
- DiContainer: `ActivatorUtilities` is used as a factory for types that haven't been registered in the DI container, but have dependencies that are registered in it.
- DiContainerV2: An optimized versios of the previous one. This will pre-calculate the constructor based on the types passed and build a factory for it.
- GenericTypeFactory: A generic factory that can resolve the TService from the DI container or creates an instance if it's not in the container.
- LazyFactory: Lazy initialization of services. `Lazy<T>` could also be used as-is if added with a concrete type at service registration time:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<Lazy<IFoo>>(sp => new Lazy<IFoo>(() => sp.GetRequiredService<IFoo>()));
    services.AddTransient<Lazy<IBar>>(sp => new Lazy<IBar>(() => sp.GetRequiredService<IBar>()));
}
```

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1620 (21H2)
Intel Core i7-10700 CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.100-preview.1.22110.4
  [Host]     : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT


```
|                        Method |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Code Size | Allocated |
|------------------------------ |----------:|---------:|---------:|------:|-------:|----------:|----------:|
|                         Naive | 387.66 ns | 3.055 ns | 2.551 ns |  1.00 | 0.1125 |     352 B |     944 B |
|                   DiContainer | 272.55 ns | 1.805 ns | 1.688 ns |  0.70 | 0.0143 |     811 B |     120 B |
|                 DiContainerV2 |  52.35 ns | 0.384 ns | 0.359 ns |  0.14 | 0.0029 |     195 B |      24 B |
|            GenericTypeFactory | 280.67 ns | 2.156 ns | 2.017 ns |  0.72 | 0.0143 |     167 B |     120 B |
|          GenericTypeFactoryV2 |  61.34 ns | 0.124 ns | 0.116 ns |  0.16 | 0.0029 |     167 B |      24 B |
|                   LazyFactory | 111.63 ns | 0.599 ns | 0.561 ns |  0.29 | 0.0248 |     167 B |     208 B |
|                               |           |          |          |       |        |           |           |
|                NaiveWithParam | 389.05 ns | 3.539 ns | 3.310 ns |  1.00 | 0.1135 |     362 B |     952 B |
|          DiContainerWithParam | 332.98 ns | 0.602 ns | 0.502 ns |  0.85 | 0.0238 |     855 B |     200 B |
|        DiContainerWithParamV2 |  65.85 ns | 0.578 ns | 0.512 ns |  0.17 | 0.0105 |     293 B |      88 B |
|   GenericTypeFactoryWithParam | 343.27 ns | 2.450 ns | 2.292 ns |  0.88 | 0.0238 |     234 B |     200 B |
| GenericTypeFactoryV2WithParam |  66.66 ns | 0.360 ns | 0.281 ns |  0.17 | 0.0105 |     172 B |      88 B |

## Sources

- https://github.com/davidfowl/DotNetCodingPatterns
