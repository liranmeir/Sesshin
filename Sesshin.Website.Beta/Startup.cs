using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sesshin.Website.Beta.Startup))]
namespace Sesshin.Website.Beta
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
