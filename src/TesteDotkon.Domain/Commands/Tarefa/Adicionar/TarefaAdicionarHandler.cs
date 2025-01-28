using Mapster;
using MediatR;
using TesteDotkon.Infra.MediatoR.CommandResponse;
using TesteDotkon.Domain.Interfaces;
using TesteDotkon.Infra.CrossCutting.NotificationPattern;
using FluentValidation;
using TesteDotkon.Infra.CrossCutting.Security.Autenticacao;

namespace TesteDotkon.Domain.Commands.Tarefa.Adicionar;

public class TarefaAdicionarHandler(
    IUsuarioAutenticado usuarioAutenticado,
    IRepositoryTarefa repositoryTarefa,
    IValidator<TarefaAdicionarRequest> validator)
    : Notifiable, IRequestHandler<TarefaAdicionarRequest, CommandResponse<TarefaAdicionarResponse>>
{
    public async Task<CommandResponse<TarefaAdicionarResponse>> Handle(TarefaAdicionarRequest request, CancellationToken cancellationToken)
    {
        var validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            AddNotification("Validação", string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
            return await Task.FromResult(new CommandResponse<TarefaAdicionarResponse>(this));
        }

        var tarefa = request.Adapt<Entities.Tarefa>();
        tarefa.DataPublicacao = DateTime.Now;
        tarefa.UsuarioId = usuarioAutenticado.UsuarioId;

        if (IsInvalid())
            return await Task.FromResult(new CommandResponse<TarefaAdicionarResponse>(this));

        await repositoryTarefa.AddAsync(tarefa, cancellationToken);

        return await Task.FromResult(new CommandResponse<TarefaAdicionarResponse>(new TarefaAdicionarResponse(tarefa.Id, "Tarefa Feita com sucesso"), this));
    }
}
