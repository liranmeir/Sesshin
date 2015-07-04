using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sesshin.Website2.Startup))]
namespace Sesshin.Website2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
