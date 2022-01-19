using MediatR;

namespace DesignPatternsInCSharp.Behavioral.Mediator.MediatR;

public class Colleague2 : INotificationHandler<Colleague>
{
    public Task Handle(Colleague notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("Colleague2 handler got called");
        return Task.CompletedTask;
    }
}
