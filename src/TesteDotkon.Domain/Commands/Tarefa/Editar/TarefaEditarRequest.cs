using MediatR;
using TesteDotkon.Infra.MediatoR.CommandResponse;
namespace TesteDotkon.Domain.Commands.Tarefa.Editar;

public class TarefaEditarRequest : IRequest<CommandResponse<TarefaEditarResponse>>
{
    public Guid TarefaId { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public DateTime DataPublicacao { get; set; } = DateTime.Now;
    public DateTime DataFechamento { get; set; }
}