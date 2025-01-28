using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteDotkon.Domain.Entities;

namespace TesteDotkon.Infra.Data.Configurations;

public class UsuarioConfigurations : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.NomeDeUsuario)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Senha)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(x => x.Tarefas)
            .WithOne(x => x.Usuario)
            .HasForeignKey(x => x.UsuarioId);

        builder.ToTable("Usuario", "DotconTodoList");
    }
}
