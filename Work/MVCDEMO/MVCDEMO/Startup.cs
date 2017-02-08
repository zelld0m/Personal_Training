using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCDEMO.Startup))]
namespace MVCDEMO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
