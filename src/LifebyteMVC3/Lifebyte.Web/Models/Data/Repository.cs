using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using Lifebyte.Web.Models.Core.Entities;
using Lifebyte.Web.Models.Core.Interfaces;
using NHibernate;
using NHibernate.Criterion;
using Expression = NHibernate.Criterion.Expression;

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
        /// <param name="orderBy">The order by clause. All order by's will be returned in ascending order.</param>
        /// <param name="skip">The number of records to skip. This helps with paging.</param>
        /// <param name="take">The number of records to take from the results. It cannot be 
        /// greater than 100.</param>
        /// <returns></returns>
        public IList<T> SelectAll(Expression<Func<T, bool>> predicate,
            Expression<Func<T, object>> orderBy, int skip, int take)
        {
            if (take > 100)
            {
                throw new InvalidEnumArgumentException("Take cannot be greater than 100.");
            }

            using (ISession session = NHibernateHelper.GetCurrentSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        var results = session.QueryOver<T>().Where(predicate)
                            .OrderBy(orderBy).Asc.Skip(skip).Take(take).List();
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

        /// <summary>
        /// Returns the next available LB Number.
        /// This is a specialized method that should be in an 
        /// IComputerRespoitory interface that implements IRepository of type Computer.
        /// http://stackoverflow.com/questions/1278276/nhibernate-criteria-select-maxid/1278577#1278577
        /// </summary>
        /// <returns></returns>
        public string NextLbNumber()
        {
            using (var session = NHibernateHelper.GetCurrentSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var result =
                            session.CreateCriteria(typeof (Computer))
                                .SetProjection(Projections.Max("LifebyteNumber"))
                                .UniqueResult();
                        transaction.Commit();

                        var id = int.Parse(result.ToString().ToUpper().Replace("LB", ""));
                        id++;

                        const string blankLbNumber = "LB0000";

                        return
                            string.Format(blankLbNumber.Substring(0, blankLbNumber.Length - id.ToString().Length) + id);
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