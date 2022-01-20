using MediatR;

namespace DesignPatternsInCSharp.Behavioral.Mediator.MediatRNotification;

public class NotificationMessage : INotification
{
    public string Message { get; set; }
}
