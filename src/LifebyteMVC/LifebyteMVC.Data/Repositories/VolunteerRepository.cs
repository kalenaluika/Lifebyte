using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using LifebyteMVC.Core;
using NHibernate.Criterion;

namespace LifebyteMVC.Data.Repositories
{
    public class VolunteerRepository
    {
        public Volunteer GetVolunteerByClaimedIdentifier(string claimedIdentifier)
        {
            var cfg = new NHibernate.Cfg.Configuration();
            cfg.Configure();
            var sessionFactory = Fluently.Configure(cfg)                
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
