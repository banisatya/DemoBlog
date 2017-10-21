using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoBlog.WebUI.Startup))]
namespace DemoBlog.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
