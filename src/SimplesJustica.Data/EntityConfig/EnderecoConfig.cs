using System.Data.Entity.ModelConfiguration;
using SimplesJustica.Domain.Entities;

namespace SimplesJustica.Data.EntityConfig
{
    public class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            Property(c => c.Logradouro)
                .IsRequired()
                .HasMaxLength(500);

            Property(c => c.Numero)
                .IsRequired()
                .HasMaxLength(15);

            Property(c => c.Bairro)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Complemento)
                .IsOptional()
                .HasMaxLength(500);

            Property(c => c.Cidade)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.UF)
                .IsRequired()
                .HasMaxLength(2);

            Property(c => c.Pais)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.CEP)
                .IsRequired()
                .HasMaxLength(9);

            Property(c => c.Principal)
                .IsOptional();
        }
    }
}
