using DesignPatternsInCSharp.Behavioral.Observer.Interfaces;

namespace DesignPatternsInCSharp.Behavioral.Observer.Implementations;

public class ConcreteObserver : ICustomObserver
{
    public int ReceivedUpdates { get; private set; } = 0;

    // Do some stuff here
    public void Update() => ReceivedUpdates++;
}
