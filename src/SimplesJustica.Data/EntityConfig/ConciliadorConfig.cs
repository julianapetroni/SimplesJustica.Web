using System.Data.Entity.ModelConfiguration;
using SimplesJustica.Domain.Entities;

namespace SimplesJustica.Data.EntityConfig
{
    public class ConciliadorConfig : EntityTypeConfiguration<Conciliador>
    {
        public ConciliadorConfig()
        {
            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            HasMany(c => c.Enderecos)
                .WithRequired(c => (Conciliador) c.Usuario)
                .HasForeignKey(c => c.UsuarioId);
        }
    }
}
