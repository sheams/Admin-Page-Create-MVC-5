using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdminPageCreate.Startup))]
namespace AdminPageCreate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
