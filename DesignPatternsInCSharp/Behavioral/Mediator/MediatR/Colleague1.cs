using MediatR;

namespace DesignPatternsInCSharp.Behavioral.Mediator.MediatR;

public class Colleague1 : INotificationHandler<Colleague>
{

    public Task Handle(Colleague notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("Colleague1 handler got called");
        return Task.CompletedTask;
    }
}
