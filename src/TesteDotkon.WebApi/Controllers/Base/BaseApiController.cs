using Microsoft.AspNetCore.Mvc;
using TesteDotkon.Infra.MediatoR.CommandResponse;

namespace TesteDotkon.WebApi.Controllers.Base;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
    protected IActionResult RespostaCustomizada<T>(CommandResponse<T> command)
        where T : class
    {
        if (command == null)
            return BadRequest();

        if (!command.Sucesso)
            return BadRequest(command);

        return Ok(command);
    }
}