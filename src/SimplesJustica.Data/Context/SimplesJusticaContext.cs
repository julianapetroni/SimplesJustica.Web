using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using SimplesJustica.Data.EntityConfig;
using SimplesJustica.Domain.Entities;
using SimplesJustica.Domain.Entities.Base;
using SimplesJustica.Domain.Enum;
using SimplesJustica.Domain.ValueObjects;

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
