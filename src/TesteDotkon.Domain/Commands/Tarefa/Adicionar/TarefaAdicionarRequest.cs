using MediatR;
using TesteDotkon.Infra.MediatoR.CommandResponse;
namespace TesteDotkon.Domain.Commands.Tarefa.Adicionar;

public class TarefaAdicionarRequest : IRequest<CommandResponse<TarefaAdicionarResponse>>
{
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public DateTime DataPublicacao { get; set; } = DateTime.Now;
    public DateTime DataFechamento { get; set; }
}