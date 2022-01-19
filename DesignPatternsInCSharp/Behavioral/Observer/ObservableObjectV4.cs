using DesignPatternsInCSharp.Behavioral.Observer.Interfaces;

namespace DesignPatternsInCSharp.Behavioral.Observer;

//Using SynchronizedCollection
public class ObservableObjectV4
{
    private readonly SynchronizedCollection<IOwnObserver> _subscribers = new();

    public int NumberOfSubscribers => _subscribers.Count;

    public void Subscribe(IOwnObserver subscriber)
    {
        //We want to prevent null instances to be added
        if (subscriber != null)
        {
            _subscribers.Add(subscriber);
        }
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
