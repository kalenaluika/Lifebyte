using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using Lifebyte.Web.Models.Core.Entities;
using Lifebyte.Web.Models.Data;
using Lifebyte.Web.Models.Services;
using NHibernate;

namespace Lifebyte.Web
{
    public class MvcApplication : HttpApplication
    {
        public static ISessionFactory SessionFactory = CreateSessionFactory();

        /// <summary>
        /// http://ayende.com/blog/4101/do-you-need-a-framework
        /// http://blog.schuager.com/2009/03/rich-client-nhibernate-session.html
        /// </summary>
        /// <returns></returns>
        private static ISessionFactory CreateSessionFactory()
        {
            var cfg = new NHibernate.Cfg.Configuration();
            cfg.Configure(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nhibernate.config"));

            return Fluently.Configure(cfg)
                .Mappings(m => m.AutoMappings
                    .Add(CreateAutomappings))
                .BuildSessionFactory();
        }

        private static AutoPersistenceModel CreateAutomappings()
        {
            return AutoMap.AssemblyOf<Volunteer>(new AutomappingConfiguration())
                .Conventions.Add<CascadeConvention>();
        }

        public static ISession CurrentSession
        {
            get { return (ISession)HttpContext.Current.Items["current.session"]; }
            set { HttpContext.Current.Items["current.session"] = value; }
        }

        protected void Application_Start()
        {
            BuildControllerFactory();

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);

            RegisterRoutes(RouteTable.Routes);

            CurrentSession = SessionFactory.OpenSession();
        }

        protected void Application_End()
        {
            if (CurrentSession != null)
            {
                CurrentSession.Dispose();
            }
        }

        /// <summary>
        /// This builds the default controllers using Inversion of Control.
        /// </summary>
        private static void BuildControllerFactory()
        {
            IWindsorContainer container = new WindsorContainer().Install(FromAssembly.This());

            var dependencyResolverService = new DependencyResolverService(container);

            dependencyResolverService.RegisterDependencies();

            ControllerFactory controllerFactory = dependencyResolverService.BuildControllerFactory(container.Kernel);
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
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
                );
        }
    }
}