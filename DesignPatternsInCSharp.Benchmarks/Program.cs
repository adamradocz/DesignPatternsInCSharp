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
                // Creational patterns
                typeof(SingletonBenchmarks),
                typeof(FactoryBenchmarks),

                // Behavioral patterns
                typeof(StateBenchmarks)
            });

        benchmarkSwitcher.Run(args);
    }
}
