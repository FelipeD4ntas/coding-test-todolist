using TesteDotkon.Core.Domain.DTOs;

namespace TesteDotkon.Domain.Commands.Tarefa.Adicionar;

public class TarefaAdicionarResponse(Guid id, string mensagem) : CommandResponseDto(id, mensagem);
