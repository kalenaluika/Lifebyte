using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using LifebyteMVC.Core;
using LifebyteMVC.Data;
using LifebyteMVC.Web.Properties;
using NHibernate.Criterion;

namespace LifebyteMVC.Web.Models.Repositories
{
    public class VolunteerRepository
    {
        public Volunteer GetVolunteerByClaimedIdentifier(string claimedIdentifier)
        {
            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(Settings.Default.LifebyteDB))
                .Mappings(m => m.AutoMappings
                    .Add(CreateAutomappings))
                .BuildSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                return session.CreateCriteria<Volunteer>()
                    .Add(Restrictions.Eq("ClaimedIdentifier", claimedIdentifier))
                    .UniqueResult<Volunteer>();
            }
        }

        private AutoPersistenceModel CreateAutomappings()
        {
            return AutoMap.AssemblyOf<Computer>(new AutomappingConfiguration())
                .Conventions.Add<CascadeConvention>();
        }
    }
}
