using TesteDotkon.Core.Domain.DTOs;

namespace TesteDotkon.Domain.Commands.Usuario.Adicionar;

public class UsuarioAdicionarResponse(Guid id, string mensagem) : CommandResponseDto(id, mensagem);
