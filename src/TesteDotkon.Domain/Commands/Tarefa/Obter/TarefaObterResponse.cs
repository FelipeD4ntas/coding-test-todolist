using TesteDotkon.Core.Domain.DTOs;

namespace TesteDotkon.Domain.Commands.Tarefa.Obter;

public class TarefaObterResponse(Guid id, string titulo, string descricao, Guid usuarioId, DateTime dataPublicacao, DateTime dataFechamento)
{
    public Guid Id { get; set; } = id;
    public string Titulo { get; set; } = titulo;
    public string Descricao { get; set; } = descricao;
    public Guid UsuarioId { get; set; } = usuarioId;
    public DateTime DataPublicacao { get; set; } = dataPublicacao;
    public DateTime DataFechamento { get; set; } = dataFechamento;
}
