using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SlickScheduler.Startup))]
namespace SlickScheduler
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
