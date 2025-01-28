using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using TesteDotkon.Application.Interfaces;
using TesteDotkon.Domain.Commands.Tarefa.Adicionar;
using TesteDotkon.Domain.Commands.Tarefa.Deletar;
using TesteDotkon.Domain.Commands.Tarefa.Editar;
using TesteDotkon.Domain.Commands.Tarefa.Listar;
using TesteDotkon.Domain.Commands.Tarefa.Obter;
using TesteDotkon.WebApi.Controllers.Base;

namespace TesteDotkon.WebApi.Controllers;

[Route("api/tarefa")]
[ApiController]
[Authorize]
public class TarefaController(ITarefaAppService tarefaAppService) : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Adicionar(TarefaAdicionarRequest request)
    {
        var commandResponse = await tarefaAppService.Adicionar(request);
        return RespostaCustomizada(commandResponse);
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> Editar([FromRoute] Guid id, TarefaEditarRequest request)
    {
        request.TarefaId = id;
        var commandResponse = await tarefaAppService.Editar(request);
        return RespostaCustomizada(commandResponse);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Deletar([FromRoute] Guid id)
    {
        var request = new TarefaDeletarRequest { Id = id };
        var commandResponse = await tarefaAppService.Deletar(request);
        return RespostaCustomizada(commandResponse);
    }

    [HttpGet("tarefas")]
    [AllowAnonymous]
    public async Task<IActionResult> Listar([FromQuery] TarefaListarRequest request)
    {
        var commandResponse = await tarefaAppService.Listar(request);
        return RespostaCustomizada(commandResponse);
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> Obter([FromRoute] Guid id)
    {
        var request = new TarefaObterRequest { Id = id };
        var commandResponse = await tarefaAppService.Obter(request);
        return RespostaCustomizada(commandResponse);
    }
}
