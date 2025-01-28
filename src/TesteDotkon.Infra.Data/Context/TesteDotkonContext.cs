using Microsoft.EntityFrameworkCore;
using TesteDotkon.Domain.Entities;
using TesteDotkon.Infra.CrossCutting.NotificationPattern.DTOs;
using TesteDotkon.Infra.Data.Configurations;

namespace TesteDotkon.Infra.Data.Context;

public class TesteDotkonContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Usuario> UsuarioDbSet { get; set; }
    public DbSet<Tarefa> TarefaDbSet { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UsuarioConfigurations());
        modelBuilder.ApplyConfiguration(new TarefaConfigurations());
        modelBuilder.Ignore<Notification>();
    }
}
