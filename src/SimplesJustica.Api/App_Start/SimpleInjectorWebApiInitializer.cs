[assembly: WebActivator.PostApplicationStartMethod(typeof(SimplesJustica.Api.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]
namespace SimplesJustica.Api.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using SimpleInjector.Lifestyles;
    using SimplesJustica.IoC;

    public static class SimpleInjectorWebApiInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            
            IoCBootstrapper.InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}