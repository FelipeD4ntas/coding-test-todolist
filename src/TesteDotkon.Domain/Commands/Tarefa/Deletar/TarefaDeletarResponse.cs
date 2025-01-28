using TesteDotkon.Core.Domain.DTOs;

namespace TesteDotkon.Domain.Commands.Tarefa.Deletar;

public class TarefaDeletarResponse(Guid id, string mensagem) : CommandResponseDto(id, mensagem);
