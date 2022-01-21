namespace DesignPatternsInCSharp.Behavioral.Observer.Interfaces;

public interface ICustomObserver
{
    int ReceivedUpdates { get; }
    void Update();
}
