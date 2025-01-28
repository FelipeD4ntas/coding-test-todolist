using Mapster;
using MediatR;
using TesteDotkon.Infra.MediatoR.CommandResponse;
using TesteDotkon.Domain.Interfaces;
using TesteDotkon.Infra.CrossCutting.NotificationPattern;
using FluentValidation;
using TesteDotkon.Infra.CrossCutting.Security.Autenticacao;

namespace TesteDotkon.Domain.Commands.Usuario.Deletar;

public class UsuarioDeletarHandler(
    IRepositoryUsuario repositoryUsuario,
    IValidator<UsuarioDeletarRequest> validator)
    : Notifiable, IRequestHandler<UsuarioDeletarRequest, CommandResponse<UsuarioDeletarResponse>>
{
    public async Task<CommandResponse<UsuarioDeletarResponse>> Handle(UsuarioDeletarRequest request, CancellationToken cancellationToken)
    {
        var validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            AddNotification("Validação", string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
            return await Task.FromResult(new CommandResponse<UsuarioDeletarResponse>(this));
        }

        var usuario = await repositoryUsuario.GetByAsync(false, p => p.Id == request.Id, cancellationToken);

        if (usuario is null)
        {
            AddNotification("Usuario", "Usuario Não Encontrado");
            return await Task.FromResult(new CommandResponse<UsuarioDeletarResponse>(this));
        }

        if (IsInvalid())
            return await Task.FromResult(new CommandResponse<UsuarioDeletarResponse>(this));

        repositoryUsuario.DeleteAsync(usuario);

        return await Task.FromResult(new CommandResponse<UsuarioDeletarResponse>(new UsuarioDeletarResponse(usuario.Id, "Usuario Deletado com sucesso"), this));
    }
}
