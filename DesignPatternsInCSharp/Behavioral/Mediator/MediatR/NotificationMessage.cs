using MediatR;

namespace DesignPatternsInCSharp.Behavioral.Mediator.MediatR;

public class NotificationMessage : INotification
{
    public string Message { get; set; }
}
