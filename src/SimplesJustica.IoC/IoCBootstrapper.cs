using SimpleInjector;
using SimplesJustica.Application.Interfaces;
using SimplesJustica.Application.Services;
using SimplesJustica.Data.Context;
using SimplesJustica.Data.UnitOfWork;
using SimplesJustica.Domain.Interfaces.UnitOfWork;

namespace SimplesJustica.IoC
{
    public class IoCBootstrapper
    {
        public static void InitializeContainer(Container container)
        {
            container.Register<SimplesJusticaContext>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<IAcusadoAppService, AcusadoAppService>(Lifestyle.Scoped);
        }
    }
}
