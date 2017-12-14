using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hangfire;
using Microsoft.Owin;
using Owin;
using MySurfboardsMVP.Controllers;
using Hangfire.Dashboard;

[assembly: OwinStartup(typeof(MyWebApplication.OwinStartup))]

namespace MyWebApplication
{



    public class MyAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            // In case you need an OWIN context, use the next line, `OwinContext` class
            // is the part of the `Microsoft.Owin` package.
            var owinContext = new OwinContext(context.GetOwinEnvironment());

            // Allow all authenticated users to see the Dashboard (potentially dangerous).
            // return owinContext.Authentication.User.Identity.IsAuthenticated;
            return true;
        }
    }






    public class OwinStartup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
                .UseSqlServerStorage("SurfboardDBConnection");

            app.UseHangfireDashboard();
            app.UseHangfireServer();

            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new MyAuthorizationFilter() }
            });



            // Background - tested and works
            // BackgroundJob.Enqueue(() => Console.WriteLine("Fire-and-forget"));


            // Recurring function (daily). Runs the scraping function.
            RecurringJob.AddOrUpdate(() => ScrappingController.ScrappingFunction(), Cron.Daily);







        }
    }
}
