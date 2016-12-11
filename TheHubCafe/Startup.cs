using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheHubCafe.Startup))]
namespace TheHubCafe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
