using DesignPatternsInCSharp.Behavioral.Observer.Interfaces;

namespace DesignPatternsInCSharp.Behavioral.Observer.Implementations;

public class ConcreteObserver : IOwnObserver
{
    private int _receivedUpdates = 0;
    public int ReceivedUpdates
    {
        get => _receivedUpdates;
    }

    //Every concrete class has to implement the ISubscriber interface
    public void Update()
    {
        //Do some stuff here
        _receivedUpdates++;
    }
}
