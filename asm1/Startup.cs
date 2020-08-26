using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(asm1.Startup))]
namespace asm1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
