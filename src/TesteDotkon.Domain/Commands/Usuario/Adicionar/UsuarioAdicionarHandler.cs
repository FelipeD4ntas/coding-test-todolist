using Mapster;
using MediatR;
using TesteDotkon.Infra.MediatoR.CommandResponse;
using TesteDotkon.Domain.Interfaces;
using TesteDotkon.Infra.CrossCutting.NotificationPattern;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace TesteDotkon.Domain.Commands.Usuario.Adicionar;

public class UsuarioAdicionarHandler(
    IRepositoryUsuario repositoryUsuario,
    IValidator<UsuarioAdicionarRequest> validator)
    : Notifiable, IRequestHandler<UsuarioAdicionarRequest, CommandResponse<UsuarioAdicionarResponse>>
{
    public async Task<CommandResponse<UsuarioAdicionarResponse>> Handle(UsuarioAdicionarRequest request, CancellationToken cancellationToken)
    {
        var validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            AddNotification("Validação", string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
            return await Task.FromResult(new CommandResponse<UsuarioAdicionarResponse>(this));
        }


        var usuarioJaCadastrado = repositoryUsuario.EmailjaCadastrado(request.Email);

        if (usuarioJaCadastrado)
        {
            AddNotification("Usuário", "Usuário já cadastrado");
            return await Task.FromResult(new CommandResponse<UsuarioAdicionarResponse>(this));
        }
        var usuario = request.Adapt<Entities.Usuario>();
        usuario.Senha = SecureIdentity.Password.PasswordHasher.Hash(request.Senha);

        if (IsInvalid())
            return await Task.FromResult(new CommandResponse<UsuarioAdicionarResponse>(this));

        await repositoryUsuario.AddAsync(usuario, cancellationToken);

        return await Task.FromResult(new CommandResponse<UsuarioAdicionarResponse>(new UsuarioAdicionarResponse(usuario.Id, "Usuário Adicionado com sucesso"), this));
    }
}
