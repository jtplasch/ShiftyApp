using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShiftyApp.MVC.Startup))]
namespace ShiftyApp.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
