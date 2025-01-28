using TesteDotkon.Core.Domain.Entities.Base;

namespace TesteDotkon.Domain.Entities;

public class Tarefa : EntidadeBase
{
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public Guid UsuarioId { get; set; }
    public DateTime DataPublicacao { get; set; } = DateTime.Now;
    public DateTime DataFechamento { get; set; }
    public bool Concluida { get; set; }
    public virtual Usuario? Usuario { get; set; }

    public void Editar(string titulo, string conteudo)
    {
        Titulo = titulo;
        Descricao = conteudo;
    }
}
