using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using SimplesJustica.Domain.Entities;

namespace SimplesJustica.Data.EntityConfig
{
    internal class EmpresaConfig : EntityTypeConfiguration<Empresa>
    {
        internal EmpresaConfig()
        {
            HasKey(x => x.Id);

            Property(x => x.DataCadastro)
                .IsRequired();

            Property(x => x.DataAtualizacao)
                .IsOptional();

            Property(c => c.Nome)
                .IsRequired();

            Property(c => c.InscricaoEstadual)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.LinhaDeNegocio)
                .IsRequired();

            Property(c => c.NomeFantasia)
                .IsRequired()
                .HasMaxLength(300);

            HasMany(c => c.Enderecos)
                .WithRequired()
                .HasForeignKey(c => c.UsuarioId);
        }
    }
}
