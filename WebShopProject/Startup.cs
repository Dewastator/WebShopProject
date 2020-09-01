using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebShopProject.Startup))]
namespace WebShopProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
