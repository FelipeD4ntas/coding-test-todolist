using TesteDotkon.Core.Domain.Entities.Base;

namespace TesteDotkon.Domain.Entities;

public class Usuario : EntidadeBase
{
    public string Nome { get; set; } = String.Empty;
    public string NomeDeUsuario { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string Senha { get; set; } = String.Empty;
    public virtual ICollection<Tarefa> Tarefas { get; set; } = [];
}
