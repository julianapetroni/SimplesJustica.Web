using System.Data.Entity.ModelConfiguration;
using SimplesJustica.Domain.Entities;

namespace SimplesJustica.Data.EntityConfig
{
    internal class AutorConfig : EntityTypeConfiguration<Autor>
    {
        internal AutorConfig()
        {
            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(30);

            Property(c => c.Sobrenome)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Nascimento)
                .IsRequired()
                .HasColumnType("date");

            HasMany(c => c.Enderecos)
                .WithRequired(c => (Autor) c.Usuario)
                .HasForeignKey(c => c.UsuarioId);
        }
    }
}
