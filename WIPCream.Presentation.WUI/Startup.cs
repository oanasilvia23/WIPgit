using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WIPCream.Presentation.WUI.Startup))]
namespace WIPCream.Presentation.WUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
