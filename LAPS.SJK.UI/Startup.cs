using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LAPS.SJK.UI.Startup))]
namespace LAPS.SJK.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
