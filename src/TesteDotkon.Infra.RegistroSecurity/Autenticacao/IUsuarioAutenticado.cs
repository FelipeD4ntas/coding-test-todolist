namespace TesteDotkon.Infra.CrossCutting.Security.Autenticacao;

public interface IUsuarioAutenticado
{
    public Guid UsuarioId { get; }
    public string UsuarioNome { get; }
    public string UsuarioEmail { get; }
    public DateTime Expiracao { get; }
}