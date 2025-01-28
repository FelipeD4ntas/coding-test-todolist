using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TesteDotkon.Application.Interfaces;
using TesteDotkon.Domain.Commands.Login;
using TesteDotkon.WebApi.Controllers.Base;

namespace TesteDotkon.WebApi.Controllers;

[Route("api/login")]
[ApiController]
public class LoginController(ILoginAppService loginAppService) : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Adicionar(LoginRequest request)
    {
        var commandResponse = await loginAppService.Login(request);
        return RespostaCustomizada(commandResponse);
    }
}
