using TesteDotkon.Infra.CrossCutting.NotificationPattern;

namespace TesteDotkon.Core.Domain.Entities.Base;

public abstract class EntidadeBase : Notifiable
{
    public Guid Id { get; set; } = default!;
}
