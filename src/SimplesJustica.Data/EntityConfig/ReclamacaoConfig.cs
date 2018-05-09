using System.Data.Entity.ModelConfiguration;
using SimplesJustica.Domain.Entities;

namespace SimplesJustica.Data.EntityConfig
{
    public class ReclamacaoConfig : EntityTypeConfiguration<Reclamacao>
    {
        public ReclamacaoConfig()
        {
            Property(c => c.Titulo)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(null);

            Property(c => c.Status)
                .IsRequired();

            HasRequired(c => c.Audor)
                .WithMany(c => c.Reclamacoes)
                .HasForeignKey(c => c.AutorId);

            HasRequired(c => c.Reu)
                .WithMany(c => c.Reclamacoes)
                .HasForeignKey(c => c.ReuId);

            HasRequired(c => c.Conciliador)
                .WithMany(c => c.Reclamacoes)
                .HasForeignKey(c => c.ConciliadorId);
        }
    }
}
