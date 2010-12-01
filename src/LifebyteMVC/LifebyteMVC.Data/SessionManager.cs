
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Automapping;
using LifebyteMVC.Core;
namespace LifebyteMVC.Data
{
    /// <summary>
    /// We have decided to not reference NHibernate in the Web project.
    /// For some reason we needed to reference NHibernate.ByteCode.Castle.
    /// That means the Data project will be responsible for session 
    /// management.
    /// 
    /// The typical way to manage NHibernate sessions is through the global.asax 
    /// file. There are many great tutorials on how to do this. Here's one I like:
    /// http://ayende.com/Blog/archive/2009/08/05/do-you-need-a-framework.aspx
    /// 
    /// We are going to use the Singleton pattern for creating a Session Factory. 
    /// Each repository will be responsible for managing the session.
    /// This is called "Every data access - Fine-grained sessions" by Germán Schuager
    /// http://blog.schuager.com/2009/03/rich-client-nhibernate-session.html
    /// 
    /// We lose the ability to lazy load, but I feel that our application is simple
    /// enough that we can live without it. This may be a design decision that we 
    /// revisit later.
    /// </summary>
    public static class SessionManager
    {
        private static ISessionFactory sessionFactory;

        /// <summary>
        /// The Singleton SessionFactory object.
        /// </summary>
        public static ISessionFactory SessionFactory 
        {
            get
            {
                if (sessionFactory == null)
                {
                    // TODO Log this to see how often we create session factories.
                    sessionFactory = InitializeSessionFactory();
                }

                return sessionFactory;
            }
        }

        private static ISessionFactory InitializeSessionFactory()
        {
            var cfg = new NHibernate.Cfg.Configuration();
            cfg.Configure();

            return Fluently.Configure(cfg)
                .Mappings(m => m.AutoMappings
                    .Add(CreateAutomappings))
                .BuildSessionFactory();
        }

        private static AutoPersistenceModel CreateAutomappings()
        {
            return AutoMap.AssemblyOf<Computer>(new AutomappingConfiguration())
                .Conventions.Add<CascadeConvention>();
        }
    }
}
