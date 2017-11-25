using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(study4lab.Startup))]
namespace study4lab
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
