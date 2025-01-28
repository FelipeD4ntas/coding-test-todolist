using TesteDotkon.Core.Domain.Interfaces.Base;
using TesteDotkon.Domain.Entities;

namespace TesteDotkon.Domain.Interfaces;

public interface IRepositoryUsuario : IRepositoryBase<Usuario>
{
    bool EmailjaCadastrado(string email);
}