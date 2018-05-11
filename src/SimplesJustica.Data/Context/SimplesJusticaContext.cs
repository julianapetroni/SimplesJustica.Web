using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SimplesJustica.Data.EntityConfig;
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
            #region Convenções

            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            #endregion

            #region Configuração

            #region Compartilhado

            modelBuilder.Properties<string>()
                .Configure(x => x.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(x => x.HasMaxLength(300));

            #endregion

            #region Específico

            //Complex type
            modelBuilder.Configurations.Add(new CpfConfig());
            modelBuilder.Configurations.Add(new CnpjConfig());
            modelBuilder.Configurations.Add(new EmailConfig());
            modelBuilder.Configurations.Add(new GeneroConfig());

            //Entities
            modelBuilder.Configurations.Add(new ReuConfig());
            modelBuilder.Configurations.Add(new AcusadoConfig());
            modelBuilder.Configurations.Add(new AutorConfig());
            modelBuilder.Configurations.Add(new ConciliadorConfig());
            modelBuilder.Configurations.Add(new EmpresaConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
            modelBuilder.Configurations.Add(new ReclamacaoConfig());

            #endregion

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
