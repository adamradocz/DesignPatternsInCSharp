using BenchmarkDotNet.Attributes;
using DesignPatternsInCSharp.Structural.Proxy;
using DesignPatternsInCSharp.Structural.Proxy.Conceptual;
using DesignPatternsInCSharp.Structural.Proxy.Dynamic;
using Microsoft.Extensions.Logging;

namespace DesignPatternsInCSharp.Benchmarks.Structural.Proxy;

[MemoryDiagnoser, DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportDiff: true)]
public class ProxyBenchmarks
{
    private readonly IBankAccount _bankAccountLogProxy;
    private readonly IBankAccount _bankAccountDynamictProxy;
    private readonly int _amount;

    public ProxyBenchmarks()
    {
        var loggerFactory = new LoggerFactory();
        _bankAccountLogProxy = new BankAccounLogProxy(loggerFactory.CreateLogger<BankAccounLogProxy>(), new BankAccount());
        _bankAccountDynamictProxy = Log<BankAccount>.As<IBankAccount>(loggerFactory.CreateLogger<BankAccount>());
        _amount = 100;
    }

    [Benchmark(Baseline = true)]
    public int ConceptualProxy() => _bankAccountLogProxy.Deposit(_amount);

    [Benchmark]
    public int DynamicProxy() => _bankAccountDynamictProxy.Deposit(_amount);
}
