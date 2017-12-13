using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hangfire;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MyWebApplication.OwinStartup))]

namespace MyWebApplication
{
    public class OwinStartup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
                .UseSqlServerStorage("SurfboardDBConnection");

            app.UseHangfireDashboard();
            app.UseHangfireServer();



            BackgroundJob.Enqueue(() => Console.WriteLine("Fire-and-forget"));



        }
    }
}
