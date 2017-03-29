using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PGS_zadanie.Startup))]
namespace PGS_zadanie
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
