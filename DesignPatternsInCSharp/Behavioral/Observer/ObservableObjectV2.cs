using DesignPatternsInCSharp.Behavioral.Observer.Interfaces;

namespace DesignPatternsInCSharp.Behavioral.Observer;

// Thread safe
public class ObservableObjectV2
{
    private delegate void EventHandler();
    private event EventHandler _notifyObserversEvent = delegate { };

    public void Subscribe(ICustomObserver observer) => _notifyObserversEvent += observer.Update;

    public void Unsubscribe(ICustomObserver observer) => _notifyObserversEvent -= observer.Update;

    public void NotifyObservers() => _notifyObserversEvent.Invoke();
}
