using MediatR;
using TesteDotkon.Infra.MediatoR.CommandResponse;
namespace TesteDotkon.Domain.Commands.Tarefa.Obter;

public class TarefaObterRequest : IRequest<CommandResponse<TarefaObterResponse>>
{
    public Guid Id { get; set; }
}