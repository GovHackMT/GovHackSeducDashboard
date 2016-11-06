using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GovHackSeduc.Startup))]
namespace GovHackSeduc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
