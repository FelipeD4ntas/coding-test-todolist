using TesteDotkon.Domain.Entities;
using TesteDotkon.Domain.Interfaces;
using TesteDotkon.Infra.CrossCutting.IoC.interfaces;
using TesteDotkon.Infra.Data.Context;
using TesteDotkon.Infra.Data.Repositories.Base;

namespace TesteDotkon.Infra.Data.Repositories;

public class RepositoryTarefa(TesteDotkonContext context) : RepositoryBase<Tarefa, TesteDotkonContext>(context), IRepositoryTarefa, IInjectScoped;