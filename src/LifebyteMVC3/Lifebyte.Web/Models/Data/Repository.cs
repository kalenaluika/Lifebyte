using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Lifebyte.Web.Models.Core.Interfaces;
using NHibernate;

namespace Lifebyte.Web.Models.Data
{
    public class Repository<T> : IRepository<T> where T : class, ICoreEntity
    {
        #region IRepository<T> Members

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
                    finally
                    {
                        NHibernateHelper.CloseSession();
                    }

                    return entity;
                }
            }
        }

        /// <summary>
        /// Finds one instance of an entity.
        /// </summary>
        /// <param name="predicate">The query expression.</param>
        /// <returns></returns>
        public T FindOne(Expression<Func<T, bool>> predicate)
        {
            using (ISession session = NHibernateHelper.GetCurrentSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        IQueryOver<T> results = session.QueryOver<T>().Where(predicate).Take(1);
                        transaction.Commit();

                        return results.List().FirstOrDefault();
                    }
                    catch
                    {
                        if (transaction.IsActive)
                        {
                            transaction.Rollback();
                        }

                        throw;
                    }
                    finally
                    {
                        NHibernateHelper.CloseSession();
                    }
                }
            }
        }

        /// <summary>
        /// Finds all of the instances.
        /// </summary>
        /// <param name="predicate">The query expression.</param>
        /// <returns></returns>
        public IList<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            using (ISession session = NHibernateHelper.GetCurrentSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        var results = session.QueryOver<T>().Where(predicate).List();
                        transaction.Commit();

                        return results;
                    }
                    catch
                    {
                        if (transaction.IsActive)
                        {
                            transaction.Rollback();
                        }

                        throw;
                    }
                    finally
                    {
                        NHibernateHelper.CloseSession();
                    }
                }
            }
        }

        #endregion
    }
}