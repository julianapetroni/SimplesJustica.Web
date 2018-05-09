using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using SimplesJustica.Domain.Entities;

namespace SimplesJustica.Data.EntityConfig
{
    internal class AcusadoConfig : EntityTypeConfiguration<Acusado>
    {
        internal AcusadoConfig()
        {
            HasKey(x => x.Id);

            Property(x => x.DataCadastro)
                .IsRequired();

            Property(x => x.DataAtualizacao)
                .IsOptional();

            Property(x => x.Email.StringValue)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(100);

            Property(x => x.CPF.StringValue)
                .HasColumnName("CPF")
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("Acusado_CpfUnique", 1) { IsUnique = true }));

            Property(c => c.Genero.StringValue)
                .HasColumnName("Genero")
                .IsRequired()
                .HasMaxLength(15);

            Property(x => x.Nome)
                .IsRequired();

            Property(x => x.Sobrenome)
                .IsRequired()
                .HasMaxLength(100);

            Property(x => x.Nascimento)
                .IsRequired()
                .HasColumnType("date");

            HasMany(x => x.Enderecos)
                .WithRequired()
                .HasForeignKey(x => x.UsuarioId);
        }
    }
}
