using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CMD.UI.Web.Startup))]
namespace CMD.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
