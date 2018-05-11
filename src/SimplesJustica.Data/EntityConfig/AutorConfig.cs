using System.Data.Entity.ModelConfiguration;
using SimplesJustica.Domain.Entities;

namespace SimplesJustica.Data.EntityConfig
{
    internal class AutorConfig : EntityTypeConfiguration<Autor>
    {
        internal AutorConfig()
        {
            HasKey(x => x.Id);

            Property(x => x.DataCadastro)
                .IsRequired();

            Property(x => x.DataAtualizacao)
                .IsOptional();

            Property(c => c.Genero.StringValue)
                .HasColumnName("Genero")
                .IsRequired()
                .HasMaxLength(15);

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
                .WithRequired()
                .HasForeignKey(c => c.UsuarioId);

            HasMany(c => c.Reclamacoes)
                .WithRequired(c => c.Audor)
                .HasForeignKey(c => c.AutorId);
        }
    }
}
