using System;
using System.Data.Entity.Migrations;
using SimplesJustica.Data.Context;
using SimplesJustica.Domain.Entities;
using SimplesJustica.Domain.Enum;
using SimplesJustica.Domain.ValueObjects;

namespace SimplesJustica.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SimplesJusticaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SimplesJusticaContext context)
        {
            base.Seed(context);

            context.Empresas.Add(new Empresa
            {
                Id = Guid.NewGuid(),
                Nome = "Microsoft Corporation",
                NomeFantasia = "Microsoft",
                Email = new Email("contact@microsoft.com"),
                CNPJ = new CNPJ("05715166000108"),
                DataCadastro = DateTime.Now,
                InscricaoEstadual = "112233",
                LinhaDeNegocio = LinhaDeNegocio.Tecnologia,
            });

            context.Empresas.Add(new Empresa
            {
                Id = Guid.NewGuid(),
                Nome = "Apple Corporation",
                NomeFantasia = "Apple",
                Email = new Email("contact@apple.com"),
                CNPJ = new CNPJ("52685341000141"),
                DataCadastro = DateTime.Now,
                InscricaoEstadual = "332211",
                LinhaDeNegocio = LinhaDeNegocio.Tecnologia,
            });

            context.SaveChanges();
        }
    }
}
