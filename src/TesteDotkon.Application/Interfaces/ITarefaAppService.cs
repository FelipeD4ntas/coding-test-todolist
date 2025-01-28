using TesteDotkon.Domain.Commands.Tarefa.Adicionar;
using TesteDotkon.Domain.Commands.Tarefa.Deletar;
using TesteDotkon.Domain.Commands.Tarefa.Editar;
using TesteDotkon.Domain.Commands.Tarefa.Listar;
using TesteDotkon.Domain.Commands.Tarefa.Obter;
using TesteDotkon.Infra.MediatoR.CommandResponse;

namespace TesteDotkon.Application.Interfaces;

public interface ITarefaAppService
{
    Task<CommandResponse<TarefaAdicionarResponse>> Adicionar(TarefaAdicionarRequest request);
    Task<CommandResponse<TarefaDeletarResponse>> Deletar(TarefaDeletarRequest request);
    Task<CommandResponse<TarefaEditarResponse>> Editar(TarefaEditarRequest request);
    Task<CommandResponse<TarefaListarResponse>> Listar(TarefaListarRequest request);
    Task<CommandResponse<TarefaObterResponse>> Obter(TarefaObterRequest request);
}
