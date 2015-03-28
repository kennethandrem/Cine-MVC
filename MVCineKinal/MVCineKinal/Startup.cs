using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCineKinal.Startup))]
namespace MVCineKinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
