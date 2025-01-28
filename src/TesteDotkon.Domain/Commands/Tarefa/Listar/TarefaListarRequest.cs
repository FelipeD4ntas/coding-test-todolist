using MediatR;
using TesteDotkon.Infra.MediatoR.CommandResponse;
namespace TesteDotkon.Domain.Commands.Tarefa.Listar;

public class TarefaListarRequest : IRequest<CommandResponse<TarefaListarResponse>>;