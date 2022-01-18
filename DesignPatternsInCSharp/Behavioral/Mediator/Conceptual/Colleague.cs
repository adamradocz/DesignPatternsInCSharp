namespace DesignPatternsInCSharp.Behavioral.Mediator;

public abstract class Colleague
{
    private Mediator _mediator;

    protected Colleague(Mediator mediator)
    {
        _mediator = mediator;
    }

    public virtual void Send(string message)
    {
        _mediator.Send(message, this);

    }

    public abstract void HandleNotification(string message);
}
