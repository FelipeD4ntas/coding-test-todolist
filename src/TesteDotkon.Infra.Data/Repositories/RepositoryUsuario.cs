using Microsoft.EntityFrameworkCore;
using TesteDotkon.Domain.Entities;
using TesteDotkon.Domain.Interfaces;
using TesteDotkon.Infra.CrossCutting.IoC.interfaces;
using TesteDotkon.Infra.Data.Context;
using TesteDotkon.Infra.Data.Repositories.Base;

namespace TesteDotkon.Infra.Data.Repositories;

public class RepositoryUsuario(TesteDotkonContext context) : RepositoryBase<Usuario, TesteDotkonContext>(context), IRepositoryUsuario, IInjectScoped
{
    public bool EmailjaCadastrado(string email)
    {
        return context.UsuarioDbSet.Any(usuario => usuario.Email == email);
    }
}