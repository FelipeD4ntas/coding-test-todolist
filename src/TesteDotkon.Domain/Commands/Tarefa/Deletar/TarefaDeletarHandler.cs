using Mapster;
using MediatR;
using TesteDotkon.Infra.MediatoR.CommandResponse;
using TesteDotkon.Domain.Interfaces;
using TesteDotkon.Infra.CrossCutting.NotificationPattern;
using FluentValidation;
using TesteDotkon.Infra.CrossCutting.Security.Autenticacao;

namespace TesteDotkon.Domain.Commands.Tarefa.Deletar;

public class TarefaDeletarHandler(
    IUsuarioAutenticado usuarioAutenticado,
    IRepositoryTarefa repositoryTarefa,
    IValidator<TarefaDeletarRequest> validator)
    : Notifiable, IRequestHandler<TarefaDeletarRequest, CommandResponse<TarefaDeletarResponse>>
{
    public async Task<CommandResponse<TarefaDeletarResponse>> Handle(TarefaDeletarRequest request, CancellationToken cancellationToken)
    {
        var validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            AddNotification("Validação", string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
            return await Task.FromResult(new CommandResponse<TarefaDeletarResponse>(this));
        }

        var tarefa = await repositoryTarefa.GetByAsync(false, p => p.Id == request.Id, cancellationToken);

        if (tarefa is null)
        {
            AddNotification("Tarefa", "Tarefa Não Encontrada");
            return await Task.FromResult(new CommandResponse<TarefaDeletarResponse>(this));
        }

        if (tarefa.UsuarioId != usuarioAutenticado.UsuarioId)
        {
            AddNotification("Tarefa", "Tarefa Não Pertence ao Usuário");
            return await Task.FromResult(new CommandResponse<TarefaDeletarResponse>(this));
        }

        if (IsInvalid())
            return await Task.FromResult(new CommandResponse<TarefaDeletarResponse>(this));

        repositoryTarefa.DeleteAsync(tarefa);

        return await Task.FromResult(new CommandResponse<TarefaDeletarResponse>(new TarefaDeletarResponse(tarefa.Id, "Tarefa Deletada com sucesso"), this));
    }
}
