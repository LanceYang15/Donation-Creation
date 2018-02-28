using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DonationCreation.Startup))]
namespace DonationCreation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
