using BenchmarkDotNet.Running;
using DesignPatternsInCSharp.Benchmarks.Creational;

namespace DesignPatternsInCSharp.Tests;

internal static class Program
{
    private static void Main(string[] args)
    {
        BenchmarkSwitcher benchmarkSwitcher = new(
            new[]
            {
                typeof(SingletonBenchmarks),
                typeof(ObserverBenchmarks)
            });

        benchmarkSwitcher.Run(args);
    }
}
