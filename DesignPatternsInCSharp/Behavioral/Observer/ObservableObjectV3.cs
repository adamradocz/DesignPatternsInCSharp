using DesignPatternsInCSharp.Behavioral.Observer.Interfaces;

namespace DesignPatternsInCSharp.Behavioral.Observer;

public class ObservableObjectV3
{
    private delegate void EventHandler();
    private event EventHandler _notifySubscribersEvent = delegate { };

    public void Subscribe(ICustomObserver observer) => _notifySubscribersEvent += observer.Update;

    public void Unsubscribe(ICustomObserver observer) => _notifySubscribersEvent -= observer.Update;

    public void NotifySubscribers() => _notifySubscribersEvent.Invoke();
}

