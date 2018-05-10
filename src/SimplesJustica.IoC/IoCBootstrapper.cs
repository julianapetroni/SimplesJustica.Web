using SimpleInjector;
using SimplesJustica.Data.Context;
using SimplesJustica.Data.UnitOfWork;
using SimplesJustica.Domain.Interfaces.UnitOfWork;

namespace SimplesJustica.IoC
{
    public class IoCBootstrapper
    {
        public static void InitializeContainer(Container container)
        {
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<SimplesJusticaContext>(Lifestyle.Scoped);
        }
    }
}
