using System.Data.Entity.ModelConfiguration;
using SimplesJustica.Domain.Enum;

namespace SimplesJustica.Data.Context
{
    public class GeneroConfig : ComplexTypeConfiguration<Genero>
    {
        public GeneroConfig()
        {
            this.Property(x => x.StringValue)
                .IsRequired()
                .HasColumnName("Genero")
                .HasMaxLength(15);
        }
    }
}
