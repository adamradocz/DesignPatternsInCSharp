using DesignPatternsInCSharp.Behavioral.Observer.Interfaces;
using System.Collections.Concurrent;

namespace DesignPatternsInCSharp.Behavioral.Observer;

//Using Concurrent
public class ObservableObjectV3
{
    //Using dictionary eliminates the chance to subscribe twice or more times with the same observer
    private readonly ConcurrentDictionary<IOwnObserver,bool> _subscribers = new();

    public int NumberOfSubscribers => _subscribers.Count;

    public void Subscribe(IOwnObserver subscriber)
    {
        //We want to prevent null instances to be added
        if (subscriber != null)
        {
            _subscribers.TryAdd(subscriber,true);
        }
    }

    public void Unsubscribe(IOwnObserver subscriber)
    {
        if (_subscribers.Count > 0)
        {
            _subscribers.Remove(subscriber, out _);
        }
    }

    public void NotifySubscribers()
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Key.Update();
        }
    }
}
