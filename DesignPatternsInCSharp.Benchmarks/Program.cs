using BenchmarkDotNet.Running;
using DesignPatternsInCSharp.Benchmarks.Creational;
using DesignPatternsInCSharp.Benchmarks.Creational.Factories;

namespace DesignPatternsInCSharp.Benchmarks;

internal static class Program
{
    private static void Main(string[] args)
    {
        BenchmarkSwitcher benchmarkSwitcher = new(
            new[]
            {
                typeof(SingletonBenchmarks),
                typeof(FactoryBenchmarks),
                typeof(ObserverBenchmarks)
            });

        benchmarkSwitcher.Run(args);
    }
}
