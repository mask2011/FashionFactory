using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewFashion.Startup))]
namespace NewFashion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
