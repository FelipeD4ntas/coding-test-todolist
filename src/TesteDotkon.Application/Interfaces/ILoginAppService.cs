using TesteDotkon.Domain.Commands.Login;
using TesteDotkon.Infra.MediatoR.CommandResponse;

namespace TesteDotkon.Application.Interfaces;

public interface ILoginAppService
{
    Task<CommandResponse<LoginResponse>> Login(LoginRequest request);
}
