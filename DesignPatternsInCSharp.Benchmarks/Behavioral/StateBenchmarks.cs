using BenchmarkDotNet.Attributes;

namespace DesignPatternsInCSharp.Benchmarks.Behavioral;

[MemoryDiagnoser, DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportDiff: true)]
public class StateBenchmarks
{
    public StateBenchmarks()
    {

    }

    [Benchmark(Baseline = true)]
    public void Naive()
    {
        var account = new DesignPatternsInCSharp.Behavioral.State.RealLife.Account();
        account.Deposit(500);
        account.Deposit(501);
        account.Withdraw(100);
        account.Deposit(10000);
    }

    [Benchmark]
    public void Stateless()
    {
        var account = new DesignPatternsInCSharp.Behavioral.State.RealLifeStateless.Account();
        account.Deposit(500);
        account.Deposit(501);
        account.Withdraw(100);
        account.Deposit(10000);
    }
}
