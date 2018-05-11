using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using SimplesJustica.Domain.ValueObjects;

namespace SimplesJustica.Data.EntityConfig
{
    public class EmailConfig : ComplexTypeConfiguration<Email>
    {
        public EmailConfig()
        {
            this.Property(c => c.StringValue)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("EmailUnique", 1) { IsUnique = true }));
        }
    }
}
