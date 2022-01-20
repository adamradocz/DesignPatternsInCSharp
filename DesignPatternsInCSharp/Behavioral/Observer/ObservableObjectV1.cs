using DesignPatternsInCSharp.Behavioral.Observer.Interfaces;

namespace DesignPatternsInCSharp.Behavioral.Observer;

public class ObservableObjectV1
{
    private readonly List<ICustomObserver> _subscribers = new();

    /// <summary>
    /// Only for testing purposes
    /// </summary>
    public int NumberOfSubscribers => _subscribers.Count;

    public void Subscribe(ICustomObserver subscriber) => _subscribers.Add(subscriber);

    public bool Unsubscribe(ICustomObserver subscriber) => _subscribers.Remove(subscriber);

    public void NotifySubscribers()
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update();
        }
    }
}
