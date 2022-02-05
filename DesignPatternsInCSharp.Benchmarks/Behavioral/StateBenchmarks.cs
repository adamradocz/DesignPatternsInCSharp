using BenchmarkDotNet.Attributes;
using DesignPatternsInCSharp.Creational.Singleton;
using System.Collections.Concurrent;

namespace DesignPatternsInCSharp.Benchmarks.Creational;

[MemoryDiagnoser, DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportDiff: true)]
public class StateBenchmarks
{
    public StateBenchmarks()
    {
        
    }

    [Benchmark(Baseline = true)]
    public void Naive()
    {
        var account = new Behavioral.State.RealLife.Account();
        account.Deposit(500);
        account.Deposit(501);
        account.Withdraw(100);
        account.Deposit(10000);
    }

    [Benchmark]
    public void Stateless()
    {
        var account = new Behavioral.State.RealLifeStateless.Account();
        account.Deposit(500);
        account.Deposit(501);
        account.Withdraw(100);
        account.Deposit(10000);
    }
}
