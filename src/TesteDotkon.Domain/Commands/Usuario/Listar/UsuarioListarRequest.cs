using MediatR;
using TesteDotkon.Infra.MediatoR.CommandResponse;
namespace TesteDotkon.Domain.Commands.Usuario.Listar;

public class UsuarioListarRequest : IRequest<CommandResponse<UsuarioListarResponse>>;