using MediatR;
using TesteDotkon.Infra.MediatoR.CommandResponse;

namespace TesteDotkon.Domain.Commands.Usuario.Deletar;

public class UsuarioDeletarRequest : IRequest<CommandResponse<UsuarioDeletarResponse>>
{
    public Guid Id { get; set; }
}