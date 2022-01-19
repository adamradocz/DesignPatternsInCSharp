using DesignPatternsInCSharp.Behavioral.Observer.Interfaces;

namespace DesignPatternsInCSharp.Behavioral.Observer;

//Straightforward, unoptimized implementation
public class ObservableObjectV1
{
    private readonly List<IOwnObserver> _subscribers = new();

    public int NumberOfSubscribers => _subscribers.Count;

    public void Subscribe(IOwnObserver subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void Unsubscribe(IOwnObserver subscriber)
    {
        if (_subscribers.Count > 0)
        {
            _subscribers.Remove(subscriber);
        }
    }

    public void NotifySubscribers()
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update();
        }
    }
}
