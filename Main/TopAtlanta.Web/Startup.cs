using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TopAtlanta.Web.Startup))]
namespace TopAtlanta.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
