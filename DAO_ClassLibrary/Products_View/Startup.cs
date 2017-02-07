using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Products_View.Startup))]
namespace Products_View
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
