using System.Data.Entity.ModelConfiguration;
using SimplesJustica.Domain.Entities;

namespace SimplesJustica.Data.EntityConfig
{
    public class EmpresaConfig : EntityTypeConfiguration<Empresa>
    {
        public EmpresaConfig()
        {
            Property(c => c.InscricaoEstadual)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.LinhaDeNegocio)
                .IsRequired();

            Property(c => c.NomeFantasia)
                .IsRequired()
                .HasMaxLength(300);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(300);

            HasMany(c => c.Enderecos)
                .WithRequired(c => (Empresa) c.Usuario)
                .HasForeignKey(c => c.UsuarioId);
        }
    }
}
