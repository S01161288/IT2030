using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OrrLab08.Startup))]
namespace OrrLab08
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
