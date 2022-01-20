using BenchmarkDotNet.Attributes;
using DesignPatternsInCSharp.Behavioral.Observer;
using DesignPatternsInCSharp.Behavioral.Observer.Implementations;
using DesignPatternsInCSharp.Behavioral.Observer.Interfaces;

namespace DesignPatternsInCSharp.Benchmarks.Behavioral;

[MemoryDiagnoser]
public class ObserverBenchmarks
{
    private readonly ICustomObserver _observer1;

    public ObserverBenchmarks ()
	{      
        _observer1 = new ConcreteObserver();
	}

    [Benchmark]
    public void ObservableObjectV1Benchmark()
    {
        ObservableObjectV1 observableObjectV1 = new();
        observableObjectV1.Subscribe(_observer1);
        observableObjectV1.NotifySubscribers();
    }

    [Benchmark]
    public void ObservableObjectV2Benchmark()
    {
        ObservableObjectV2 observableObjectV2 = new();
        observableObjectV2.Subscribe(_observer1);
        observableObjectV2.NotifySubscribers();
    }

    [Benchmark]
    public void ObservableObjectV5Benchmark()
    {
        ObservableObjectV3 observableObjectV5 = new();
        observableObjectV5.Subscribe(_observer1);
        observableObjectV5.NotifySubscribers();
    }

    [Benchmark]
    public void ObservableObjectV6Benchmark()
    {
        ObservableObjectV4 observableObjectV6 = new();
        observableObjectV6.Subscribe(_observer1);
        observableObjectV6.NotifySubscribers();
    }
}
