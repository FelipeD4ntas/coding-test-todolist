using TesteDotkon.Core.Domain.DTOs;
using TesteDotkon.Domain.DTOs;

namespace TesteDotkon.Domain.Commands.Tarefa.Listar;

public class TarefaListarResponse(Guid id, string mensagem, List<TarefaDto> tarefas) : CommandResponseDto(id, mensagem)
{
    public List<TarefaDto> Tarefas { get; set; } = tarefas;
}
