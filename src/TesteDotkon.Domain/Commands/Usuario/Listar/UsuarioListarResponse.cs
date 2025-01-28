using TesteDotkon.Core.Domain.DTOs;
using TesteDotkon.Domain.DTOs;

namespace TesteDotkon.Domain.Commands.Usuario.Listar;

public class UsuarioListarResponse(Guid id, string mensagem, List<UsuarioDto> tarefas) : CommandResponseDto(id, mensagem)
{
    public List<UsuarioDto> Usuarios { get; set; } = tarefas;
}
