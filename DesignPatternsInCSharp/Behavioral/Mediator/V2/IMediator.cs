namespace DesignPatternsInCSharp.Behavioral.Mediator.V2;

public interface IMediator
{
    void Send(string message, Colleague colleague);
}
