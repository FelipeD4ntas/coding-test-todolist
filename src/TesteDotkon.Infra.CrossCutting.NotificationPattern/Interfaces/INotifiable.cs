using FluentValidation.Results;
using TesteDotkon.Infra.CrossCutting.NotificationPattern.DTOs;

namespace TesteDotkon.Infra.CrossCutting.NotificationPattern.Interfaces;

public interface INotifiable
{
    IReadOnlyCollection<Notification> Notifications { get; }
    void AddNotification(string property, string message);
    void AddNotification(Notification notification);
    void AddNotifications(IReadOnlyCollection<Notification> notifications);
    void AddNotifications(ValidationResult validationResult);
    bool IsValid();
    bool IsInvalid();
    void ClearNotifications();
}
