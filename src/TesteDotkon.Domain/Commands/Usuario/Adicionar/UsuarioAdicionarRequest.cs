using MediatR;
using TesteDotkon.Infra.MediatoR.CommandResponse;
namespace TesteDotkon.Domain.Commands.Usuario.Adicionar;

public class UsuarioAdicionarRequest : IRequest<CommandResponse<UsuarioAdicionarResponse>>
{
    public required string Nome { get; set; }
    public required string NomeDeUsuario { get; set; }
    public required string Email { get; set; }
    public required string Senha { get; set; }
    public required string ConfirmacaoSenha { get; set; }
}