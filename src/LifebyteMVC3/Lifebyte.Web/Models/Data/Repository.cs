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
        public T Insert(T entity, object id)
        {
            using (ISession session = NHibernateHelper.GetCurrentSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(entity, id);
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

        public T Update(T entity)
        {
            using (ISession session = NHibernateHelper.GetCurrentSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(entity);
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
        /// Selects one instance of an entity.
        /// </summary>
        /// <param name="predicate">The LINQ expression.</param>
        /// <returns></returns>
        public T SelectOne(Expression<Func<T, bool>> predicate)
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
        /// Selects the first 100 instances.
        /// </summary>
        /// <param name="predicate">The LINQ expression.</param>
        /// <returns></returns>
        public IList<T> SelectAll(Expression<Func<T, bool>> predicate)
        {
            using (ISession session = NHibernateHelper.GetCurrentSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        var results = session.QueryOver<T>().Where(predicate).Take(100).List();
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
    }
}