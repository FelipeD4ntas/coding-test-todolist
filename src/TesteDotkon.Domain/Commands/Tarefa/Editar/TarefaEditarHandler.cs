using MediatR;
using TesteDotkon.Infra.MediatoR.CommandResponse;
using TesteDotkon.Domain.Interfaces;
using TesteDotkon.Infra.CrossCutting.NotificationPattern;
using FluentValidation;
using TesteDotkon.Infra.CrossCutting.Security.Autenticacao;

namespace TesteDotkon.Domain.Commands.Tarefa.Editar;

public class TarefaEditarHandler(
    IUsuarioAutenticado usuarioAutenticado,
    IRepositoryTarefa repositoryTarefa,
    IValidator<TarefaEditarRequest> validator)
    : Notifiable, IRequestHandler<TarefaEditarRequest, CommandResponse<TarefaEditarResponse>>
{
    public async Task<CommandResponse<TarefaEditarResponse>> Handle(TarefaEditarRequest request, CancellationToken cancellationToken)
    {
        var validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            AddNotification("Validação", string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
            return await Task.FromResult(new CommandResponse<TarefaEditarResponse>(this));
        }

        var tarefa = await repositoryTarefa.GetByAsync(false, p => p.Id == request.TarefaId, cancellationToken);

        if (tarefa is null)
        {
            AddNotification("Tarefa", "Tarefa Não Encontrada");
            return await Task.FromResult(new CommandResponse<TarefaEditarResponse>(this));
        }

        if (tarefa.UsuarioId != usuarioAutenticado.UsuarioId)
        {
            AddNotification("Tarefa", "Tarefa Não Pertence ao Usuário");
            return await Task.FromResult(new CommandResponse<TarefaEditarResponse>(this));
        }

        tarefa.Editar(request.Titulo, request.Descricao);

        if (IsInvalid())
            return await Task.FromResult(new CommandResponse<TarefaEditarResponse>(this));

        repositoryTarefa.Update(tarefa);

        return await Task.FromResult(new CommandResponse<TarefaEditarResponse>(new TarefaEditarResponse(tarefa.Id, "Tarefa Atualizada com sucesso"), this));
    }
}
