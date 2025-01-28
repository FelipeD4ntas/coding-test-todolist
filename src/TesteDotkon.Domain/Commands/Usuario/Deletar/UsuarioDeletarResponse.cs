using TesteDotkon.Core.Domain.DTOs;

namespace TesteDotkon.Domain.Commands.Usuario.Deletar;

public class UsuarioDeletarResponse(Guid id, string mensagem) : CommandResponseDto(id, mensagem);
