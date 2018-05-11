using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using SimplesJustica.Domain.ValueObjects;

namespace SimplesJustica.Data.EntityConfig
{
    public class CnpjConfig : ComplexTypeConfiguration<CNPJ>
    {
        public CnpjConfig()
        {
            Property(x => x.SemFormatacao)
                .HasColumnName("CNPJ")
                .IsRequired()
                .HasMaxLength(14)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("CnpjUnique", 1) { IsUnique = true }));

            Ignore(x => x.Formatado);
        }
    }
}
