using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InsectCatalog.Startup))]
namespace InsectCatalog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
