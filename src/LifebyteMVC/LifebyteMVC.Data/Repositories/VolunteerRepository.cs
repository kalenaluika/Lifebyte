using LifebyteMVC.Core;
using NHibernate.Criterion;

namespace LifebyteMVC.Data.Repositories
{
    public class VolunteerRepository : BaseRespository<Volunteer>
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
