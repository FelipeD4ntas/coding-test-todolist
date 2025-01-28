namespace TesteDotkon.Core.Domain.DTOs;

public class CommandResponseDto(Guid id, string mensagem)
{
    public Guid Id { get; } = id;
    public string Mensagem { get; } = mensagem;
}
