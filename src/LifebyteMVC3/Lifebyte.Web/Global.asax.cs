using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Lifebyte.Web.Models.Services;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Lifebyte.Web.Models.Core.Interfaces;
using Lifebyte.Web.Controllers;
using Castle.Windsor.Installer;

namespace Lifebyte.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
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