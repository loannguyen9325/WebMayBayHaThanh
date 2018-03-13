using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebMayBayHaThanh.Startup))]
namespace WebMayBayHaThanh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
