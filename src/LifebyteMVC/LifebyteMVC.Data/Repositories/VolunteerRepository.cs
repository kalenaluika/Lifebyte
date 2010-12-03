using LifebyteMVC.Core.Interfaces;
using LifebyteMVC.Core.Model;
using NHibernate.Criterion;

namespace LifebyteMVC.Data.Repositories
{
    public class VolunteerRepository : Respository<Volunteer>
    {
        public Volunteer GetVolunteerByClaimedIdentifier(string claimedIdentifier)
        {
            using (Session)
            {
                using (var transaction = Session.BeginTransaction())
                {
                    return Session.CreateCriteria<Volunteer>()
                        .Add(Restrictions.Eq("ClaimedIdentifier", claimedIdentifier))
                        .UniqueResult<Volunteer>();
                }
            }
        }
    }
}
