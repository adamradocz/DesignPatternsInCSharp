using DesignPatternsInCSharp.Behavioral.Observer.Interfaces;

namespace DesignPatternsInCSharp.Behavioral.Observer;

public class ObservableObjectV5
{
    private delegate void EventHandler();
    private event EventHandler _notifySubscribers = delegate { };

    public void Subscribe(IOwnObserver observer)
    {
        _notifySubscribers += observer.Update;
    }

    public void NotifySubscribers()
    {
        _notifySubscribers.Invoke();
    }
}

