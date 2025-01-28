using MediatR;
using TesteDotkon.Infra.MediatoR.CommandResponse;
using TesteDotkon.Domain.Interfaces;
using TesteDotkon.Infra.CrossCutting.NotificationPattern;
using TesteDotkon.Domain.DTOs;

namespace TesteDotkon.Domain.Commands.Usuario.Listar;

public class UsuarioListarHandler(
    IRepositoryUsuario repositoryUsuario)
    : Notifiable, IRequestHandler<UsuarioListarRequest, CommandResponse<UsuarioListarResponse>>
{
    public async Task<CommandResponse<UsuarioListarResponse>> Handle(UsuarioListarRequest request, CancellationToken cancellationToken)
    {
        var usuarios = await repositoryUsuario.ListAsync(false);

        if (usuarios is null || !usuarios.Any())
        {
            AddNotification("Usuario", "Nenhuma Usuario");
            return await Task.FromResult(new CommandResponse<UsuarioListarResponse>(this));
        }

        var usuarioTasks = usuarios.Select(async usuario =>
        {
            var autor = await repositoryUsuario.GetByAsync(false, u => u.Id == usuario.Id, cancellationToken);
            return new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            };
        });

        var usuarioDtos = await Task.WhenAll(usuarioTasks);

        var response = new UsuarioListarResponse(
                           Guid.NewGuid(),
                           "Listagem de usuarios realizada com sucesso",
                           usuarioDtos.ToList());

        return await Task.FromResult(new CommandResponse<UsuarioListarResponse>(response, this));
    }
}
