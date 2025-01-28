using MediatR;
using TesteDotkon.Infra.MediatoR.CommandResponse;

namespace TesteDotkon.Domain.Commands.Tarefa.Deletar;

public class TarefaDeletarRequest : IRequest<CommandResponse<TarefaDeletarResponse>>
{
    public Guid Id { get; set; }
}