using System.Data.Entity.ModelConfiguration;
using SimplesJustica.Domain.Entities;

namespace SimplesJustica.Data.EntityConfig
{
    internal class EmpresaConfig : EntityTypeConfiguration<Empresa>
    {
        internal EmpresaConfig()
        {
            Property(c => c.InscricaoEstadual)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.LinhaDeNegocio)
                .IsRequired();

            Property(c => c.NomeFantasia)
                .IsRequired()
                .HasMaxLength(300);
        }
    }
}
