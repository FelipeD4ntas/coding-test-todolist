using MediatR;
using TesteDotkon.Infra.MediatoR.CommandResponse;

namespace TesteDotkon.Domain.Commands.Login;

public class LoginRequest : IRequest<CommandResponse<LoginResponse>>
{
    public required string Email { get; set; }
    public required string Senha { get; set; }
}
