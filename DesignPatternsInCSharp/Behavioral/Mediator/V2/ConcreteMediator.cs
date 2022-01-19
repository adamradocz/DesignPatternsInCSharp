namespace DesignPatternsInCSharp.Behavioral.Mediator.V2;

public class ConcreteMediator : IMediator
{
    private List<Colleague> _colleagues = new();

    public void Register(Colleague colleague)
    {
        colleague.SetMediator(this);
        _colleagues.Add(colleague);
    }

    public void Send(string message, Colleague colleague) => _colleagues.Where(c => c != colleague).ToList().ForEach(c => c.HandleNotification(message));
}
