using BenchmarkDotNet.Attributes;
using DesignPatternsInCSharp.Structural.Proxy.DynamicProxy;
using DesignPatternsInCSharp.Structural.Proxy.SmartProxy;

namespace DesignPatternsInCSharp.Benchmarks.Structural.Proxy;

[MemoryDiagnoser, DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportDiff: true)]
public class ProxyBenchmarks
{
    private readonly IBankAccount _bankAccountSmartProxy;
    private readonly IBankAccount _bankAccountDynamictProxy;

    public ProxyBenchmarks()
    {
        _bankAccountSmartProxy = new BankAccountSmartProxy();
        _bankAccountDynamictProxy = Log<BankAccount>.As<IBankAccount>();
    }

    [Benchmark(Baseline = true)]
    public void SmartProxy()
    {
        _bankAccountSmartProxy.Deposit(100);
        _ = _bankAccountSmartProxy.Withdraw(50);
    }

    [Benchmark()]
    public void DynamicProxy()
    {
        _bankAccountDynamictProxy.Deposit(100);
        _ = _bankAccountDynamictProxy.Withdraw(50);
    }
}
