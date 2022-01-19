using DesignPatternsInCSharp.Behavioral.Observer.Interfaces;
using System.Reactive.Subjects;

namespace DesignPatternsInCSharp.Behavioral.Observer;

public class ObservableObjectV6
{
    public Subject<object> SubsciberSubject { get; } = new Subject<object>();

    public IObservable<object> Observable => SubsciberSubject;

    public void Subscribe(IOwnObserver observer)
    {
        Observable.Subscribe(_ => observer.Update());
    }

    public void NotifySubscribers()
    {
        SubsciberSubject.OnNext(string.Empty);
    }
}
