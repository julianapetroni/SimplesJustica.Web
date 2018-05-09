using System.Data.Entity.ModelConfiguration;
using SimplesJustica.Domain.Entities;

namespace SimplesJustica.Data.EntityConfig
{
    public class AcusadoConfig : EntityTypeConfiguration<Acusado>
    {
        public AcusadoConfig()
        {
            Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(30);

            Property(x => x.Sobrenome)
                .IsRequired()
                .HasMaxLength(100);

            Property(x => x.Nascimento)
                .IsRequired()
                .HasColumnType("date");

            HasMany(x => x.Enderecos)
                .WithRequired(x => (Acusado) x.Usuario)
                .HasForeignKey(x => x.UsuarioId);
        }
    }
}
