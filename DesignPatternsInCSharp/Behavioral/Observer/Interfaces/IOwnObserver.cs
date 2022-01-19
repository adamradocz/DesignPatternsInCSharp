namespace DesignPatternsInCSharp.Behavioral.Observer.Interfaces;

public interface IOwnObserver
{
    int ReceivedUpdates { get; }
    void Update();
}
