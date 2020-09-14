using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EntityFrameworkCodeFirst.Startup))]
namespace EntityFrameworkCodeFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
