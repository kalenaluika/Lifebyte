using Lifebyte.Web.Models.Core.Interfaces;

namespace Lifebyte.Web.Models.Data
{
    public class Repository<T> : IRepository<T> where T : ICoreEntity
    {
        public void Save(T entity)
        {
            var session = MvcApplication.CurrentSession;
            var transaction = session.BeginTransaction();
            transaction.Begin();
            session.SaveOrUpdate(entity);
            transaction.Commit();
        }
    }
}