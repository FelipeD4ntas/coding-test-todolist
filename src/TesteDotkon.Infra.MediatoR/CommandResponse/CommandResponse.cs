using TesteDotkon.Infra.CrossCutting.NotificationPattern.DTOs;
using TesteDotkon.Infra.CrossCutting.NotificationPattern.Interfaces;

namespace TesteDotkon.Infra.MediatoR.CommandResponse;

public class CommandResponse<T> where T : class
{
    public bool Sucesso { get; set; }
    public T? Dados { get; set; }
    public IReadOnlyCollection<Notification> Notificacoes { get; set; }

    public CommandResponse(T dados, INotifiable notificacoes)
    {
        Sucesso = true;
        Dados = dados;
        Notificacoes = notificacoes.Notifications;
    }

    public CommandResponse(INotifiable notificacoes)
    {
        Sucesso = false;
        Dados = null;
        Notificacoes = notificacoes.Notifications;
    }
}
