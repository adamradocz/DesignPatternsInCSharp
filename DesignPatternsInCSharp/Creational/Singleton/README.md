# Singleton Pattern

![Singleton UML Diagram](singleton.svg)

GoF Definition: Ensures a class has only one instance, and provides a global point of access to it.

## Benchmark

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|          Method |     Mean |     Error |    StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Allocated |
|---------------- |---------:|----------:|----------:|------:|--------:|----------:|-------:|----------:|
|         V1Naive | 1.757 μs | 0.0326 μs | 0.0289 μs |  1.00 |    0.00 |      1 KB | 0.2346 |      3 KB |
|       V2Locking | 2.038 μs | 0.0404 μs | 0.0779 μs |  1.16 |    0.04 |      1 KB | 0.2365 |      3 KB |
| V3BetterLocking | 1.871 μs | 0.0371 μs | 0.0678 μs |  1.07 |    0.04 |      1 KB | 0.2327 |      3 KB |
|      V4LessLazy | 1.855 μs | 0.0371 μs | 0.0917 μs |  0.98 |    0.03 |      1 KB | 0.2327 |      3 KB |
|    V5NestedLazy | 1.856 μs | 0.0366 μs | 0.0958 μs |  1.05 |    0.04 |      1 KB | 0.2327 |      3 KB |
|       V6LazyOfT | 1.910 μs | 0.0381 μs | 0.0962 μs |  1.08 |    0.06 |      1 KB | 0.2327 |      3 KB |

## Sources

- https://github.com/ardalis/DesignPatternsInCSharp
- https://csharpindepth.com/articles/singleton
