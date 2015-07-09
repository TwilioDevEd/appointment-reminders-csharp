using Hangfire;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AppointmentReminders.Web.Startup))]

namespace AppointmentReminders.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
                .UseSqlServerStorage("AppointmentReminders");

            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}