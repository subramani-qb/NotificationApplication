using Microsoft.AspNet.SignalR;
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

            string connectionString = "data source=DESKTOP-6DNTMS0\\SQLSERVER2012; initial catalog=NotificationDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            GlobalHost.DependencyResolver.UseSqlServer(connectionString);

            app.MapSignalR();
        }
    }
}
