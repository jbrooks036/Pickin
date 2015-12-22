using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pickin.Startup))]
namespace Pickin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
