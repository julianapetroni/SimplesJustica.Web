using System.Data.Entity.ModelConfiguration;
using SimplesJustica.Domain.Entities;
using SimplesJustica.Domain.Entities.Base;

namespace SimplesJustica.Data.EntityConfig
{
    public class ReuConfig : EntityTypeConfiguration<Reu>
    {
        public ReuConfig()
        {
            HasKey(x => x.Id);

            Property(x => x.DataCadastro)
                .IsRequired();

            Property(x => x.DataAtualizacao)
                .IsOptional();

            Property(c => c.Nome)
                .IsRequired();

            HasMany(c => c.Enderecos)
                .WithRequired()
                .HasForeignKey(c => c.UsuarioId);

            HasMany(c => c.Reclamacoes)
                .WithRequired(c => c.Reu);

            Map<Empresa>(c => c.Requires("Type").HasValue("Empresa").HasColumnType("varchar").HasMaxLength(7));
            Map<Acusado>(c => c.Requires("Type").HasValue("Acusado"));
        }
    }
}
