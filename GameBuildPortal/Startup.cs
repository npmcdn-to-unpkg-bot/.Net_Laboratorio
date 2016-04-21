using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameBuildPortal.Startup))]
namespace GameBuildPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
