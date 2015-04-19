using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Introconduit1.Startup))]
namespace Introconduit1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
