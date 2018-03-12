using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectLev.Startup))]
namespace ProjectLev
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
