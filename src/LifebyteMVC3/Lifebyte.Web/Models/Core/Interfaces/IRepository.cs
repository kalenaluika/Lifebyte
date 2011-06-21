using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Lifebyte.Web.Models.Core.Interfaces
{
    public interface IRepository<T> where T : ICoreEntity
    {
        T Insert(T entity, object id);

        T Update(T entity);

        /// <summary>
        /// Finds one instance of an entity.
        /// </summary>
        /// <param name="predicate">The query expression.</param>
        /// <returns></returns>
        T SelectOne(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Finds all of the instances.
        /// </summary>
        /// <param name="predicate">The query expression.</param>
        /// <returns></returns>
        IList<T> SelectAll(Expression<Func<T, bool>> predicate);
    }
}