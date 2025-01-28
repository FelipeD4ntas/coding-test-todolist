namespace TesteDotkon.Domain.DTOs;

public class TarefaDto
{
    public Guid Id { get; set; }
    public string? Titulo { get; set; }
    public string? Descricao { get; set; } 
    public string? NomeDeUsuario { get; set; }
    public Guid UsuarioId { get; set; }
    public DateTime DataPublicacao { get; set; }
    public DateTime? DataFechamento { get; set; }
}
