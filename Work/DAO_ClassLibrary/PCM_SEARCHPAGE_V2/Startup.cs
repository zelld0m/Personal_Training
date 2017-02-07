using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PCM_SEARCHPAGE_V2.Startup))]
namespace PCM_SEARCHPAGE_V2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
