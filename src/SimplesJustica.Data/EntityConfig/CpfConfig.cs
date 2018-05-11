using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using SimplesJustica.Domain.ValueObjects;

namespace SimplesJustica.Data.EntityConfig
{
    internal class CpfConfig : ComplexTypeConfiguration<CPF>
    {
        internal CpfConfig()
        {
            Property(cpf => cpf.SemFormatacao)
                .HasColumnName("CPF")
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("CpfUnique", 1) { IsUnique = true }));

            Ignore(cpf => cpf.Formatado);
        }
    }
}
