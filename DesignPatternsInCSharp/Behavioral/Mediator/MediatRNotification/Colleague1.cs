using MediatR;

namespace DesignPatternsInCSharp.Behavioral.Mediator.MediatRNotification;

public class Colleague1 : INotificationHandler<NotificationMessage>
{

    public Task Handle(NotificationMessage notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Colleague1 handler got called. Message: {notification.Message}");
        return Task.CompletedTask;
    }
}
