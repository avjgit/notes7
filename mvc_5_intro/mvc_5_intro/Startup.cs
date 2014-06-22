using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvc_5_intro.Startup))]
namespace mvc_5_intro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
