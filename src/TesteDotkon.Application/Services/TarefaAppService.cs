using TesteDotkon.Infra.MediatoR.CommandResponse;
using TesteDotkon.Application.Interfaces;
using TesteDotkon.Infra.CrossCutting.IoC.interfaces;
using TesteDotkon.Infra.CrossCutting.NotificationPattern;
using TesteDotkon.Domain.Interfaces;
using TesteDotkon.Domain.Commands.Tarefa.Adicionar;
using MediatR;
using TesteDotkon.Domain.Commands.Tarefa.Deletar;
using TesteDotkon.Domain.Commands.Tarefa.Editar;
using TesteDotkon.Domain.Commands.Tarefa.Listar;
using TesteDotkon.Domain.Commands.Tarefa.Obter;

namespace TesteDotkon.Application.Services;

public class TarefaAppService(IUnitOfWork unitOfWork, ISender mediator)
    : Notifiable, ITarefaAppService, IInjectScoped
{
    public async Task<CommandResponse<TarefaAdicionarResponse>> Adicionar(TarefaAdicionarRequest request)
    {
        var commandResponse = await mediator.Send(request);
        AddNotifications(commandResponse.Notificacoes);

        if (IsValid())
            await unitOfWork.CommitAsync();

        return commandResponse;
    }

    public async Task<CommandResponse<TarefaDeletarResponse>> Deletar(TarefaDeletarRequest request)
    {
        var commandResponse = await mediator.Send(request);
        AddNotifications(commandResponse.Notificacoes);

        if (IsValid())
            await unitOfWork.CommitAsync();

        return commandResponse;
    }

    public async Task<CommandResponse<TarefaEditarResponse>> Editar(TarefaEditarRequest request)
    {
        var commandResponse = await mediator.Send(request);
        AddNotifications(commandResponse.Notificacoes);

        if (IsValid())
            await unitOfWork.CommitAsync();

        return commandResponse;
    }

    public async Task<CommandResponse<TarefaListarResponse>> Listar(TarefaListarRequest request)
    {
        var commandResponse = await mediator.Send(request);
        AddNotifications(commandResponse.Notificacoes);

        return commandResponse;
    }

    public async Task<CommandResponse<TarefaObterResponse>> Obter(TarefaObterRequest request)
    {
        var commandResponse = await mediator.Send(request);
        AddNotifications(commandResponse.Notificacoes);

        return commandResponse;
    }
}
