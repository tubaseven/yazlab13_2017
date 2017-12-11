using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Yazlab_13.Startup))]
namespace Yazlab_13
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
