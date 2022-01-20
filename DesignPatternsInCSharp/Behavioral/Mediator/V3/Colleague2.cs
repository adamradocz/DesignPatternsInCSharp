namespace DesignPatternsInCSharp.Behavioral.Mediator.V3;

public class Colleague2 : Colleague
{
    public override void HandleNotification(string message)
    {
        Console.WriteLine($"Colleague2 receives notification messagge: {message}");
    }
}
