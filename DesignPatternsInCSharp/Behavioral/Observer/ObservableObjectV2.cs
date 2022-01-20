using DesignPatternsInCSharp.Behavioral.Observer.Interfaces;

namespace DesignPatternsInCSharp.Behavioral.Observer;

// Thread safe
public class ObservableObjectV2
{
    private readonly List<ICustomObserver> _subscribers = new();
    private readonly object _lock = new();

    /// <summary>
    /// Only for testing purposes
    /// </summary>
    public int NumberOfSubscribers => _subscribers.Count;

    public void Subscribe(ICustomObserver subscriber)
    {
        lock (_lock)
        {
            _subscribers.Add(subscriber);
        }
    }

    public bool Unsubscribe(ICustomObserver subscriber)
    {
        lock (_lock)
        {
            return _subscribers.Remove(subscriber);
        }
    }

    public void NotifySubscribers()
    {
        lock (_lock)
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Update();
            }
        }
    }
}
