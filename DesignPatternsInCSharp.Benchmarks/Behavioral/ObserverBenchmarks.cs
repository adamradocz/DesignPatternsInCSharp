using BenchmarkDotNet.Attributes;
using DesignPatternsInCSharp.Behavioral.Observer;
using DesignPatternsInCSharp.Behavioral.Observer.Implementations;
using DesignPatternsInCSharp.Behavioral.Observer.Interfaces;

namespace DesignPatternsInCSharp.Benchmarks.Behavioral;

[MemoryDiagnoser]
public class ObserverBenchMarks
{
    private readonly IOwnObserver _observer1;

    public ObserverBenchMarks ()
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
    public void ObservableObjectV3Benchmark()
    {
        ObservableObjectV3 observableObjectV3 = new();
        observableObjectV3.Subscribe(_observer1);
        observableObjectV3.NotifySubscribers();
    }

    [Benchmark]
    public void ObservableObjectV4Benchmark()
    {
        ObservableObjectV4 observableObjectV4 = new();
        observableObjectV4.Subscribe(_observer1);
        observableObjectV4.NotifySubscribers();
    }

    [Benchmark]
    public void ObservableObjectV5Benchmark()
    {
        ObservableObjectV5 observableObjectV5 = new();
        observableObjectV5.Subscribe(_observer1);
        observableObjectV5.NotifySubscribers();
    }

    [Benchmark]
    public void ObservableObjectV6Benchmark()
    {
        ObservableObjectV6 observableObjectV6 = new();
        observableObjectV6.Subscribe(_observer1);
        observableObjectV6.NotifySubscribers();
    }
}
