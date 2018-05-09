using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimplesJustica.Web.Startup))]
namespace SimplesJustica.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
