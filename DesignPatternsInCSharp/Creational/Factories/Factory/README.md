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
    services.AddTransient<Lazy<IFoo>>(sp => new Lazy<IFoo>(() => sp.GetRequiredService<IFoo>());
    services.AddTransient<Lazy<IBar>>(sp => new Lazy<IBar>(() => sp.GetRequiredService<IBar>());
}
```

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1469 (21H2)
Intel Core i7-10700 CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|                      Method |      Mean |    Error |   StdDev | Ratio | Code Size |  Gen 0 | Allocated |
|---------------------------- |----------:|---------:|---------:|------:|----------:|-------:|----------:|
|                       Naive | 375.57 ns | 0.498 ns | 0.442 ns |  1.00 |     352 B | 0.1125 |     944 B |
|                 DiContainer | 255.55 ns | 0.501 ns | 0.444 ns |  0.68 |     811 B | 0.0143 |     120 B |
|               DiContainerV2 |  55.64 ns | 0.134 ns | 0.125 ns |  0.15 |     195 B | 0.0029 |      24 B |
|          GenericTypeFactory | 306.31 ns | 0.383 ns | 0.339 ns |  0.82 |     167 B | 0.0172 |     144 B |
|                 LazyFactory | 110.15 ns | 0.261 ns | 0.244 ns |  0.29 |     167 B | 0.0248 |     208 B |
|                             |           |          |          |       |           |        |           |
|              NaiveWithParam | 389.04 ns | 0.510 ns | 0.425 ns |  1.00 |     363 B | 0.1135 |     952 B |
|        DiContainerWithParam | 303.55 ns | 0.414 ns | 0.387 ns |  0.78 |     855 B | 0.0238 |     200 B |
|      DiContainerWithParamV2 |  64.59 ns | 0.292 ns | 0.274 ns |  0.17 |      40 B | 0.0105 |      88 B |
| GenericTypeFactoryWithParam | 337.53 ns | 0.299 ns | 0.265 ns |  0.87 |     234 B | 0.0267 |     224 B |


## Sources

- https://github.com/davidfowl/DotNetCodingPatterns
