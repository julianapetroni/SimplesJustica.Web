using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SimplesJustica.Domain.Entities;

namespace SimplesJustica.Data.Context
{
    public class SimplesJusticaContext : DbContext
    {
        public SimplesJusticaContext()
            :base("DefaultConnection")
        {
        }

        public DbSet<Acusado> Acusados { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Conciliador> Conciliadores { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Reclamacao> Reclamacoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>().Configure(x => x.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(x => x.HasMaxLength(255));
        }
    }
}
