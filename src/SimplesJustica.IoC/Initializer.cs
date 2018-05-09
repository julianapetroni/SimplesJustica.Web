using SimpleInjector;
using SimplesJustica.Data.Context;
using SimplesJustica.Data.UnitOfWork;
using SimplesJustica.Domain.Interfaces.UnitOfWork;

namespace SimplesJustica.IoC
{
    public class Initializer
    {
        public static void Bootstrapper(Container container)
        {
            container.Register<SimplesJusticaContext>();
            container.Register<IUnitOfWork, UnitOfWork>();
        }
    }
}
