using DesignPatternsInCSharp.Behavioral.Observer.Interfaces;

namespace DesignPatternsInCSharp.Behavioral.Observer;

public class ObservableObjectV1
{
    private readonly List<ICustomObserver> _observers = new();

    /// <summary>
    /// Only for testing purposes
    /// </summary>
    public int NumberOfSubscribers => _observers.Count;

    public void Subscribe(ICustomObserver observer) => _observers.Add(observer);

    public bool Unsubscribe(ICustomObserver observer) => _observers.Remove(observer);

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update();
        }
    }
}
