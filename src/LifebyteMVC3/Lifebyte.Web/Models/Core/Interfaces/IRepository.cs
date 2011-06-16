using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Lifebyte.Web.Models.Core.Interfaces
{
    public interface IRepository<T> where T : ICoreEntity
    {
        T Save(T entity);

        /// <summary>
        /// Finds one instance of an entity.
        /// </summary>
        /// <param name="predicate">The query expression.</param>
        /// <returns></returns>
        T FindOne(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Finds all of the instances.
        /// </summary>
        /// <param name="predicate">The query expression.</param>
        /// <returns></returns>
        IList<T> FindAll(Expression<Func<T, bool>> predicate);
    }
}