namespace DesignPatternsInCSharp.Behavioral.Mediator.V3;

public interface IMediator
{
    public void Send(string message, Colleague colleague);
}
