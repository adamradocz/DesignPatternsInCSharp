namespace DesignPatternsInCSharp.Behavioral.Mediator;

public class ConcreteMediator : Mediator
{
    public Colleague1 Colleague1V1 { get; set; }
    public Colleague2 Colleague2V1 { get; set; }

    public override void Send(string message, Colleague colleague)
    {
        if (colleague == Colleague1V1)
        {
            Colleague2V1.HandleNotification(message);
        }

        if (colleague == Colleague2V1)
        {
            Colleague1V1.HandleNotification(message);
        }
    }
}
