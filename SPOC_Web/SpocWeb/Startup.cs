using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpocWeb.Startup))]
namespace SpocWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
