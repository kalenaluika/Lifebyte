using System;
using System.IO;
using System.Web;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using Lifebyte.Web.Models.Core.Entities;
using Lifebyte.Web.Models.Core.Interfaces;
using NHibernate;
using NHibernate.Cfg;

namespace Lifebyte.Web.Models.Data
{
    public class Repository<T> : IRepository<T> where T : ICoreEntity
    {
        public static ISessionFactory SessionFactory = CreateSessionFactory();

        public T Save(T entity)
        {
            using (var session = SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(entity);
                        transaction.Commit();
                    }
                    catch
                    {
                        if (transaction.IsActive)
                        {
                            transaction.Rollback();
                        }

                        throw;
                    }

                    return entity;
                }
            }
        }

        /// <summary>
        /// http://ayende.com/blog/4101/do-you-need-a-framework
        /// http://blog.schuager.com/2009/03/rich-client-nhibernate-session.html
        /// </summary>
        /// <returns></returns>
        private static ISessionFactory CreateSessionFactory()
        {
            var cfg = new Configuration();
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
    }
}