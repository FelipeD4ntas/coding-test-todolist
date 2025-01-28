using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteDotkon.Domain.Entities;

namespace TesteDotkon.Infra.Data.Configurations;

public class TarefaConfigurations : IEntityTypeConfiguration<Tarefa>
{
    public void Configure(EntityTypeBuilder<Tarefa> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Titulo)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Descricao)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.DataPublicacao)
            .IsRequired();

        builder.Property(x => x.DataFechamento)
            .IsRequired();

        builder.Property(x => x.Concluida)
            .IsRequired();

        builder.HasOne(x => x.Usuario)
            .WithMany(x => x.Tarefas)
            .HasForeignKey(x => x.UsuarioId);

        builder.ToTable("Tarefa", "DotconTodoList");
    }
}
