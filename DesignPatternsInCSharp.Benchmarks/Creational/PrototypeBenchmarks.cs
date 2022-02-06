using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace DesignPatternsInCSharp.Benchmarks.Creational;

[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[MemoryDiagnoser, DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportDiff: true)]
public class PrototypeBenchmarks
{
    private readonly DesignPatternsInCSharp.Creational.Prototype.Naive.Person _naivePerson;
    private readonly DesignPatternsInCSharp.Creational.Prototype.MemberwiseClone.Person _memberwiseClonePerson;

    public PrototypeBenchmarks()
    {
        string name = "Jane";
        int age = 69;
        string streetName = "Main Street";
        int houseNumber = 123;

        _naivePerson = new()
        {
            Name = name,
            Age = age,
            Address = new ()
            {
                StreetName = streetName,
                HouseNumber = houseNumber
            }
        };

        _memberwiseClonePerson = new()
        {
            Name = name,
            Age = age,
            Address = new()
            {
                StreetName = streetName,
                HouseNumber = houseNumber
            }
        };
    }

    [BenchmarkCategory("Shallow")]
    [Benchmark(Baseline = true)]
    public DesignPatternsInCSharp.Creational.Prototype.Naive.Person NaiveShallowClone() => _naivePerson.ShallowClone();

    [BenchmarkCategory("Deep")]
    [Benchmark(Baseline = true)]
    public DesignPatternsInCSharp.Creational.Prototype.Naive.Person NaiveDeepClone() => _naivePerson.DeepClone();

    [BenchmarkCategory("Shallow")]
    [Benchmark]
    public DesignPatternsInCSharp.Creational.Prototype.MemberwiseClone.Person MemberwiseCloneShallowClone() => _memberwiseClonePerson.ShallowClone();

    [BenchmarkCategory("Deep")]
    [Benchmark]
    public DesignPatternsInCSharp.Creational.Prototype.MemberwiseClone.Person MemberwiseCloneDeepClone() => _memberwiseClonePerson.DeepClone();
}
