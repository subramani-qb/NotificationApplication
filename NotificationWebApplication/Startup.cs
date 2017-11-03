using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NotificationWebApplication.Startup))]
namespace NotificationWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
