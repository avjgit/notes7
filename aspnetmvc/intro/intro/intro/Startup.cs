using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(intro.Startup))]
namespace intro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
