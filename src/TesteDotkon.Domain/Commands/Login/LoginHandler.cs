using MediatR;
using SecureIdentity.Password;
using TesteDotkon.Infra.MediatoR.CommandResponse;
using TesteDotkon.Domain.Interfaces;
using TesteDotkon.Infra.CrossCutting.NotificationPattern;
using Microsoft.Extensions.Configuration;
using TesteDotkon.Infra.CrossCutting.Security.Token;

namespace TesteDotkon.Domain.Commands.Login;

public class LoginHandler(
    IConfiguration configuration,
    IRepositoryUsuario repositoryUsuario) : Notifiable, IRequestHandler<LoginRequest, CommandResponse<LoginResponse>>
{
    public async Task<CommandResponse<LoginResponse>> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var usuario = await repositoryUsuario.GetByAsync(false, p => p.Email == request.Email, cancellationToken);
        if (usuario is null)
        {
            AddNotification("Usuário", "Usuário Não Encontrado");
            return await Task.FromResult(new CommandResponse<LoginResponse>(this));
        }
            
        if (!PasswordHasher.Verify(usuario.Senha, request.Senha))
        {
            AddNotification("Usuário", "Login Incorreto");
            return await Task.FromResult(new CommandResponse<LoginResponse>(this));
        }

        if (IsInvalid())
            return await Task.FromResult(new CommandResponse<LoginResponse>(this));

        var token = new TokenBuilder(configuration)
           .WithUserId(usuario.Id.ToString())
           .WithUserEmail(usuario.Email)
           .WithUserName(usuario.Nome)
           .Build();

        var loginUsuarioResponse = new LoginResponse(usuario.Id, usuario.Nome, usuario.Email, token);

        return await Task.FromResult(new CommandResponse<LoginResponse>(loginUsuarioResponse, this));
    }
}
