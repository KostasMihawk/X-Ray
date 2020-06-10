using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(X_Ray.Startup))]
namespace X_Ray
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
