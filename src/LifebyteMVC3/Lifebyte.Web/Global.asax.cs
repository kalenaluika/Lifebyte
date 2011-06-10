using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Lifebyte.Web.Models.Services;
using Lifebyte.Web.Models.Data;

namespace Lifebyte.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            BuildControllerFactory();

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);

            RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_End()
        {
            NHibernateHelper.CloseSessionFactory();
        }

        /// <summary>
        /// This builds the default controllers using Inversion of Control.
        /// </summary>
        private static void BuildControllerFactory()
        {
            var container = new WindsorContainer().Install(FromAssembly.This());

            var dependencyResolverService = new DependencyResolverService(container);

            dependencyResolverService.RegisterDependencies();

            var controllerFactory = dependencyResolverService.BuildControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );
        }
    }
}