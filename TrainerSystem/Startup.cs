using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrainerSystem.Startup))]
namespace TrainerSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
