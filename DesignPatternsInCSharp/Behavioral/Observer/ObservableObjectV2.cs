using DesignPatternsInCSharp.Behavioral.Observer.Interfaces;

namespace DesignPatternsInCSharp.Behavioral.Observer;

//Straightforward, unoptimized implementation
public class ObservableObjectV2
{
    private readonly List<IOwnObserver> _subscribers = new();
    private readonly object _observerLock = new object();

    public int NumberOfSubscribers => _subscribers.Count;

    public void Subscribe(IOwnObserver subscriber)
    {
        //We want to prevent null instances to be added
        lock (_observerLock)
        {
            if (subscriber != null)
            {
                _subscribers.Add(subscriber);
            }
        }
    }

    public void Unsubscribe(IOwnObserver subscriber)
    {
        lock (_observerLock)
        {
            if (_subscribers.Count > 0)
            {
                _subscribers.Remove(subscriber);
            }
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
