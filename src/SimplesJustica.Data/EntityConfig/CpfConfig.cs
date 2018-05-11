using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using SimplesJustica.Domain.ValueObjects;

namespace SimplesJustica.Data.EntityConfig
{
    public class CpfConfig : ComplexTypeConfiguration<CPF>
    {
        public CpfConfig()
        {
            this.Property(cpf => cpf.SemFormatacao)
                .HasColumnName("CPF")
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("CpfUnique", 1) { IsUnique = true }));

            this.Ignore(cpf => cpf.Formatado);
        }
    }
}
