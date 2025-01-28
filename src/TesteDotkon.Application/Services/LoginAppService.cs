using TesteDotkon.Infra.MediatoR.CommandResponse;
using TesteDotkon.Application.Interfaces;
using TesteDotkon.Infra.CrossCutting.IoC.interfaces;
using TesteDotkon.Infra.CrossCutting.NotificationPattern;
using MediatR;
using TesteDotkon.Domain.Commands.Login;

namespace TesteDotkon.Application.Services;

public class LoginAppService(ISender mediator)
    : Notifiable, ILoginAppService, IInjectScoped
{
    public async Task<CommandResponse<LoginResponse>> Login(LoginRequest request)
    {
        var commandResponse = await mediator.Send(request);
        return commandResponse;
    }
}
