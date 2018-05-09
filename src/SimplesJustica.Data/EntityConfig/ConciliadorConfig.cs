using System.Data.Entity.ModelConfiguration;
using SimplesJustica.Domain.Entities;

namespace SimplesJustica.Data.EntityConfig
{
    internal class ConciliadorConfig : EntityTypeConfiguration<Conciliador>
    {
        internal ConciliadorConfig()
        {
            HasKey(x => x.Id);

            Property(x => x.DataCadastro)
                .IsRequired();

            Property(x => x.DataAtualizacao)
                .IsOptional();

            Property(x => x.Email.StringValue)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            HasMany(c => c.Enderecos)
                .WithRequired(c => (Conciliador) c.Usuario)
                .HasForeignKey(c => c.UsuarioId);
        }
    }
}
