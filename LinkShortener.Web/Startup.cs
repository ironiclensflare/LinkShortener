using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LinkShortener.Web.Startup))]
namespace LinkShortener.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
