using System.Data.Entity.ModelConfiguration;
using SimplesJustica.Domain.Enum;

namespace SimplesJustica.Data.Context
{
    internal class GeneroConfig : ComplexTypeConfiguration<Genero>
    {
        internal GeneroConfig()
        {
            Property(x => x.StringValue)
                .IsRequired()
                .HasColumnName("Genero")
                .HasMaxLength(15);
        }
    }
}
