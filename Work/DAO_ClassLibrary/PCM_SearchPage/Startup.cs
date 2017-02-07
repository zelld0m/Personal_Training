using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PCM_SearchPage.Startup))]
namespace PCM_SearchPage
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
