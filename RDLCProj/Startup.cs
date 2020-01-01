using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RDLCProj.Startup))]
namespace RDLCProj
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
