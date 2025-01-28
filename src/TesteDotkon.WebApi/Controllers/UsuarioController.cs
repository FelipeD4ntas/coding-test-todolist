using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TesteDotkon.Application.Interfaces;
using TesteDotkon.Domain.Commands.Usuario.Deletar;
using TesteDotkon.Domain.Commands.Usuario.Listar;
using TesteDotkon.Domain.Commands.Usuario.Adicionar;
using TesteDotkon.WebApi.Controllers.Base;

namespace TesteDotkon.WebApi.Controllers;

[Route("api/usuario")]
[ApiController]
[Authorize]
public class UsuarioController(IUsuarioAppService usuarioAppService) : BaseApiController
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Adicionar(UsuarioAdicionarRequest request)
    {
        var commandResponse = await usuarioAppService.Adicionar(request);
        return RespostaCustomizada(commandResponse);
    }


    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Deletar([FromRoute] Guid id)
    {
        var request = new UsuarioDeletarRequest { Id = id };
        var commandResponse = await usuarioAppService.Deletar(request);
        return RespostaCustomizada(commandResponse);
    }

    [HttpGet("usuarios")]
    [AllowAnonymous]
    public async Task<IActionResult> Listar([FromQuery] UsuarioListarRequest request)
    {
        var commandResponse = await usuarioAppService.Listar(request);
        return RespostaCustomizada(commandResponse);
    }
}
