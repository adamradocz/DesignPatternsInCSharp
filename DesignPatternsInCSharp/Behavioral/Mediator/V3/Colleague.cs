namespace DesignPatternsInCSharp.Behavioral.Mediator;

public abstract class Colleague
{
    private IMediator _mediator;

    internal void SetMediator(IMediator mediator) => _mediator = mediator;

    public virtual void Send(string message) => _mediator.Send(message, this);

    public abstract void HandleNotification(string message);
}
