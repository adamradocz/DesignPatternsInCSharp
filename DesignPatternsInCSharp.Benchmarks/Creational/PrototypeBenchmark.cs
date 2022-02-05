using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using DesignPatternsInCSharp.Creational.Prototype;

namespace DesignPatternsInCSharp.Benchmarks.Creational;

[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[MemoryDiagnoser, DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportDiff: true)]
public class PrototypeBenchmark
{
    private readonly Person _person;
    private readonly PersonShallowCopy _personShallowCopy;
    private readonly PersonDeepCopy _personDeepCopy;

    public PrototypeBenchmark()
    {
        _person = new Person() { Age = 42, Name = "Jack Daniels", IdInfo = new IdInfo(666) };
        _personShallowCopy = new PersonShallowCopy() { Age = 42, Name = "Jack Daniels", IdInfo = new IdInfo(666) };
        _personDeepCopy = new PersonDeepCopy() { Age = 42, Name = "Jack Daniels", IdInfo = new IdInfo(666) };
    }

    [BenchmarkCategory("Shallow")]
    [Benchmark(Baseline = true)]
    public void PrototypeV1_Without_IClonable_Shallow()
    {
        var person = _person.ShallowCopy();
    }

    [BenchmarkCategory("Deep")]
    [Benchmark(Baseline = true)]
    public void PrototypeV1_Without_IClonable_Deep()
    {
        var person = _person.DeepCopy();
    }

    [BenchmarkCategory("Shallow")]
    [Benchmark]
    public void PrototypeV2_With_IClonable_Shallow()
    {
        var person = _personShallowCopy.Clone();
    }

    [BenchmarkCategory("Deep")]
    [Benchmark]
    public void PrototypeV2_With_IClonable_Deep()
    {
        var person = _personDeepCopy.Clone();
    }
}
