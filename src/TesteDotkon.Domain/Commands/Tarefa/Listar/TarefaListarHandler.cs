using Mapster;
using MediatR;
using TesteDotkon.Infra.MediatoR.CommandResponse;
using TesteDotkon.Domain.Interfaces;
using TesteDotkon.Infra.CrossCutting.NotificationPattern;
using FluentValidation;
using TesteDotkon.Domain.DTOs;

namespace TesteDotkon.Domain.Commands.Tarefa.Listar;

public class TarefaListarHandler(
    IRepositoryUsuario repositoryUsuario,
    IRepositoryTarefa repositoryTarefa)
    : Notifiable, IRequestHandler<TarefaListarRequest, CommandResponse<TarefaListarResponse>>
{
    public async Task<CommandResponse<TarefaListarResponse>> Handle(TarefaListarRequest request, CancellationToken cancellationToken)
    {
        var tarefas = await repositoryTarefa.ListAsync(false);

        if (tarefas is null || !tarefas.Any())
        {
            AddNotification("Tarefa", "Nenhuma Tarefa");
            return await Task.FromResult(new CommandResponse<TarefaListarResponse>(this));
        }

        var tarefaTasks = tarefas.Select(async tarefa =>
        {
            var autor = await repositoryUsuario.GetByAsync(false, u => u.Id == tarefa.UsuarioId, cancellationToken);
            return new TarefaDto
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                NomeDeUsuario = autor?.NomeDeUsuario,
                UsuarioId = tarefa.UsuarioId,
                DataPublicacao = tarefa.DataPublicacao,
                DataFechamento = tarefa.DataFechamento
            };
        });

        var tarefaDtos = await Task.WhenAll(tarefaTasks);

        var response = new TarefaListarResponse(
                           Guid.NewGuid(),
                           "Listagem de tarefas realizada com sucesso",
                           tarefaDtos.ToList());

        return await Task.FromResult(new CommandResponse<TarefaListarResponse>(response, this));
    }
}
