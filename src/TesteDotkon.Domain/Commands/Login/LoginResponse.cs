namespace TesteDotkon.Domain.Commands.Login;

public class LoginResponse(Guid id, string nome, string email, string token)
{
    public Guid Id { get; } = id;
    public string Nome { get; } = nome;
    public string Email { get; } = email;
    public string Token { get; } = token;
}