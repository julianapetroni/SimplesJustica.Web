using System.Data.Entity.Migrations;
using SimplesJustica.Data.Context;

namespace SimplesJustica.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SimplesJusticaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}
