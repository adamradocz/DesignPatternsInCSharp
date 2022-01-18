﻿namespace DesignPatternsInCSharp.Behavioral.Mediator;

public class Colleague2 : Colleague
{
    public Colleague2(Mediator mediator) : base(mediator)
    {}

    public override void HandleNotification(string message)
    {
        Console.WriteLine($"Colleague2 receives notification messagge: {message}");
    }
}