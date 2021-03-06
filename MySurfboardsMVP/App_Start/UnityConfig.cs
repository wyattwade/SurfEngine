using Microsoft.Practices.Unity;
using MySurfboardsMVP.Services;
using System.Web.Http;
using Unity.WebApi;

namespace MySurfboardsMVP
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<SurfboardDataService, SurfboardDataService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}