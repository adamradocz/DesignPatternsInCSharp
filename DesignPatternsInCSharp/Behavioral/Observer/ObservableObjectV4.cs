using DesignPatternsInCSharp.Behavioral.Observer.Interfaces;
using System.Reactive.Subjects;

namespace DesignPatternsInCSharp.Behavioral.Observer;

public class ObservableObjectV4
{
    public Subject<string> Subject { get; } = new Subject<string>();

    public IObservable<string> Observable => Subject;

    public IDisposable Subscribe(ICustomObserver observer) => Observable.Subscribe(_ => observer.Update());

    public void NotifyObservers() => Subject.OnNext(string.Empty);
}
