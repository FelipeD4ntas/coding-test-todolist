using TesteDotkon.Core.Domain.DTOs;

namespace TesteDotkon.Domain.Commands.Tarefa.Editar;

public class TarefaEditarResponse(Guid id, string mensagem) : CommandResponseDto(id, mensagem);
