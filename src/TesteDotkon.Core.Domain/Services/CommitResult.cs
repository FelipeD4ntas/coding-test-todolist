using TesteDotkon.Infra.CrossCutting.NotificationPattern.DTOs;
using TesteDotkon.Infra.CrossCutting.NotificationPattern.Interfaces;

namespace TesteDotkon.Core.Domain.Services;

public class CommitResult(bool sucesso, INotifiable notificacoes)
{
    public bool Sucesso { get; } = sucesso;
    public IReadOnlyCollection<Notification> Notificacoes { get; } = notificacoes.Notifications;
}
