namespace DesignPatternsInCSharp.Behavioral.Mediator.Conceptual;

public abstract class Mediator
{
    public abstract void Send(string message, Colleague colleague);
}
