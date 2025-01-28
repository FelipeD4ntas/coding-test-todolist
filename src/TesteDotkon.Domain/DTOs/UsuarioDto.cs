namespace TesteDotkon.Domain.DTOs;

public class UsuarioDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = String.Empty;
    public string NomeDeUsuario { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
}
