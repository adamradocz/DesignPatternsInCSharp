namespace DesignPatternsInCSharp.Behavioral.Observer;

public class ObservableObjectV3
{
    public delegate void EventHandler();
    private event EventHandler _notifyObserversEvent = delegate { };

    public void Subscribe(EventHandler methodToInvoke) => _notifyObserversEvent += methodToInvoke;

    public void Unsubscribe(EventHandler methodToInvoke) => _notifyObserversEvent -= methodToInvoke;

    public void NotifyObservers() => _notifyObserversEvent.Invoke();
}

