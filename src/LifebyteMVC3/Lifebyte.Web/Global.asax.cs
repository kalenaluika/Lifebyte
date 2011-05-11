using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Lifebyte.Web.Controllers;
using Lifebyte.Web.Models.Core.Interfaces;
using Lifebyte.Web.Models.Services;
using System.Web;

namespace Lifebyte.Web
{
    public class MvcApplication : HttpApplication
    {
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
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            var container = new WindsorContainer().Install(FromAssembly.This());

            container.Register(AllTypes.FromThisAssembly()
                            .BasedOn<IController>()
                            .If(Component.IsInSameNamespaceAs<HomeController>())
                            .If(t => t.Name.EndsWith("Controller"))
                            .Configure(c => c.LifeStyle.Transient))
                     .Register(Component.For<IFormsAuthenticationService>()
                            .ImplementedBy(typeof(FormsAuthenticationService))
                            .LifeStyle.Transient);

            var controllerFactory = new DependencyResolverService(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);


            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);            
        }
    }
}