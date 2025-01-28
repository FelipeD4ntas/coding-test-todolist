using MediatR;
using TesteDotkon.Infra.MediatoR.CommandResponse;
using TesteDotkon.Domain.Interfaces;
using TesteDotkon.Infra.CrossCutting.NotificationPattern;
using FluentValidation;

namespace TesteDotkon.Domain.Commands.Tarefa.Obter;

public class TarefaObterHandler(
    IRepositoryTarefa repositoryTarefa,
    IValidator<TarefaObterRequest> validator)
    : Notifiable, IRequestHandler<TarefaObterRequest, CommandResponse<TarefaObterResponse>>
{
    public async Task<CommandResponse<TarefaObterResponse>> Handle(TarefaObterRequest request, CancellationToken cancellationToken)
    {
        var validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            AddNotification("Validação", string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
            return await Task.FromResult(new CommandResponse<TarefaObterResponse>(this));
        }

        var tarefa = await repositoryTarefa.GetByAsync(false, p => p.Id == request.Id, cancellationToken);

        if (tarefa is null)
        {
            AddNotification("Tarefa", "Tarefa Não Encontrada");
            return await Task.FromResult(new CommandResponse<TarefaObterResponse>(this));
        }

        if (IsInvalid())
            return await Task.FromResult(new CommandResponse<TarefaObterResponse>(this));

        var response = new TarefaObterResponse(tarefa.Id, tarefa.Titulo, tarefa.Descricao, tarefa.UsuarioId, tarefa.DataPublicacao, tarefa.DataFechamento);

        return await Task.FromResult(new CommandResponse<TarefaObterResponse>(response, this));
    }
}
