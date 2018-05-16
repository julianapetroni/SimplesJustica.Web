[assembly: WebActivator.PostApplicationStartMethod(typeof(SimplesJustica.Web.App_Start.SimpleInjectorInitializer), "Initialize")]
namespace SimplesJustica.Web.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;
    using SimplesJustica.IoC;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    
    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            IoCBootstrapper.InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}