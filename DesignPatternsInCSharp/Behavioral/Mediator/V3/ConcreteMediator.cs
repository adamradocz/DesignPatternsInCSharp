namespace DesignPatternsInCSharp.Behavioral.Mediator;

public class ConcreteMediator : IMediator
{
    private List<Colleague> _colleagues = new();

    public void Register(Colleague colleague)
    {
        colleague.SetMediator(this);
        _colleagues.Add(colleague);
    }

    public T CreateColleague<T>() where T : Colleague, new()
    {
        var colleague = new T();
        colleague.SetMediator(this);
        _colleagues.Add(colleague);
        return colleague;
    }

    public void Send(string message, Colleague colleague) => _colleagues.Where(c => c != colleague).ToList().ForEach(c => c.HandleNotification(message));
}
