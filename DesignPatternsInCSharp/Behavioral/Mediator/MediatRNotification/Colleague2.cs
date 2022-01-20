using MediatR;

namespace DesignPatternsInCSharp.Behavioral.Mediator.MediatRNotification;

public class Colleague2 : INotificationHandler<NotificationMessage>
{
    public Task Handle(NotificationMessage notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Colleague2 handler got called. Message: {notification.Message}");
        return Task.CompletedTask;
    }
}
