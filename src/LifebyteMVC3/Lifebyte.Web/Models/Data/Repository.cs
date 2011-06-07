using Lifebyte.Web.Models.Core.Interfaces;
using NHibernate;

namespace Lifebyte.Web.Models.Data
{
    public class Repository<T> : IRepository<T> where T : ICoreEntity
    {
        public T Save(T entity)
        {
            using (ISession session = NHibernateHelper.GetCurrentSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
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

                    NHibernateHelper.CloseSession();

                    return entity;
                }
            }
        }
    }
}