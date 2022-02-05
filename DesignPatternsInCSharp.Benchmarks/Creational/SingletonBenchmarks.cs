using BenchmarkDotNet.Attributes;
using DesignPatternsInCSharp.Creational.Singleton;
using System.Collections.Concurrent;

namespace DesignPatternsInCSharp.Benchmarks.Creational;

// Source: https://github.com/ardalis/DesignPatternsInCSharp
[MemoryDiagnoser, DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportDiff: true)]
public class SingletonBenchmarks
{
    private readonly ParallelOptions _parallelOptions;
    private readonly List<string> _strings;

    public SingletonBenchmarks()
    {
        _parallelOptions = new ParallelOptions()
        {
            MaxDegreeOfParallelism = 4,
        };

        _strings = new List<string>() { "one", "two", "three", "four" };
    }

    [Benchmark(Baseline = true)]
    public void V1Naive()
    {
        var instances = new ConcurrentDictionary<SingletonServiceV1, byte>();
        Parallel.ForEach(_strings, _parallelOptions, _ => instances.TryAdd(SingletonServiceV1.Instance, 0));
    }

    [Benchmark]
    public void V2Locking()
    {
        var instances = new ConcurrentDictionary<SingletonServiceV2, byte>();
        Parallel.ForEach(_strings, _parallelOptions, _ => instances.TryAdd(SingletonServiceV2.Instance, 0));
    }

    [Benchmark]
    public void V3BetterLocking()
    {
        var instances = new ConcurrentDictionary<SingletonServiceV3, byte>();
        Parallel.ForEach(_strings, _parallelOptions, _ => instances.TryAdd(SingletonServiceV3.Instance, 0));
    }

    [Benchmark]
    public void V4LessLazy()
    {
        var instances = new ConcurrentDictionary<SingletonServiceV4, byte>();
        Parallel.ForEach(_strings, _parallelOptions, _ => instances.TryAdd(SingletonServiceV4.Instance, 0));
    }

    [Benchmark]
    public void V5NestedLazy()
    {
        var instances = new ConcurrentDictionary<SingletonServiceV5, byte>();
        Parallel.ForEach(_strings, _parallelOptions, _ => instances.TryAdd(SingletonServiceV5.Instance, 0));
    }

    [Benchmark]
    public void V6LazyOfT()
    {
        var instances = new ConcurrentDictionary<SingletonServiceV6, byte>();
        Parallel.ForEach(_strings, _parallelOptions, _ => instances.TryAdd(SingletonServiceV6.Instance, 0));
    }
}
