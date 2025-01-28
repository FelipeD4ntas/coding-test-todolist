using TesteDotkon.Domain.Commands.Usuario.Deletar;
using TesteDotkon.Domain.Commands.Usuario.Listar;
using TesteDotkon.Domain.Commands.Usuario.Adicionar;
using TesteDotkon.Infra.MediatoR.CommandResponse;

namespace TesteDotkon.Application.Interfaces;

public interface IUsuarioAppService
{
    Task<CommandResponse<UsuarioAdicionarResponse>> Adicionar(UsuarioAdicionarRequest request);
    Task<CommandResponse<UsuarioDeletarResponse>> Deletar(UsuarioDeletarRequest request);
    Task<CommandResponse<UsuarioListarResponse>> Listar(UsuarioListarRequest request);
}
