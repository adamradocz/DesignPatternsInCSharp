namespace DesignPatternsInCSharp.Behavioral.Mediator;

public class Colleague1 : Colleague
{
    public override void HandleNotification(string message)
    {
        Console.WriteLine($"Colleague1 receives notification messagge: {message}");
    }
}
