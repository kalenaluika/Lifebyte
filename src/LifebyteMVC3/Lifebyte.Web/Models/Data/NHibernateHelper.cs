using System;
using System.IO;
using System.Web;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using Lifebyte.Web.Models.Core.Entities;
using NHibernate;
using NHibernate.Cfg;

namespace Lifebyte.Web.Models.Data
{
    /// <summary>
    /// This code was adapted to us Fluent NHibernate and a custom config file.
    /// http://nhforge.org/doc/nh/en/index.html
    /// </summary>
    public static class NHibernateHelper
    {
        private const string CurrentSessionKey = "nhibernate.current_session";
        private static readonly ISessionFactory sessionFactory;

        static NHibernateHelper()
        {
            var cfg = new Configuration();
            // http://ayende.com/blog/4101/do-you-need-a-framework
            cfg.Configure(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nhibernate.config"));

            sessionFactory = Fluently.Configure(cfg)
                .Mappings(m => m.AutoMappings.Add(CreateAutomappings))
                .BuildSessionFactory();
        }

        private static AutoPersistenceModel CreateAutomappings()
        {
            return AutoMap.AssemblyOf<Volunteer>(new AutomappingConfiguration())
                .Conventions.Add<CascadeConvention>();
        }

        public static ISession GetCurrentSession()
        {
            var context = HttpContext.Current;
            var currentSession = context.Items[CurrentSessionKey] as ISession;

            if (currentSession == null)
            {
                currentSession = sessionFactory.OpenSession();
                context.Items[CurrentSessionKey] = currentSession;
            }

            return currentSession;
        }

        public static void CloseSession()
        {
            var context = HttpContext.Current;
            var currentSession = context.Items[CurrentSessionKey] as ISession;

            if (currentSession == null)
            {
                // No current session
                return;
            }

            currentSession.Close();
            context.Items.Remove(CurrentSessionKey);
        }

        public static void CloseSessionFactory()
        {
            if (sessionFactory != null)
            {
                sessionFactory.Close();
            }
        }
    }
}