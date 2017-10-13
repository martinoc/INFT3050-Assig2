using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Better.Startup))]
namespace Better
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
