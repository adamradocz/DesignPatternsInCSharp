using BenchmarkDotNet.Running;
using DesignPatternsInCSharp.Benchmarks.Behavioral;
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
                typeof(PrototypeBenchmarks),

                // Behavioral patterns
                typeof(StateBenchmarks)
            });

        benchmarkSwitcher.Run(args);
    }
}
