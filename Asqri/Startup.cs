using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Asqri.Startup))]
namespace Asqri
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
