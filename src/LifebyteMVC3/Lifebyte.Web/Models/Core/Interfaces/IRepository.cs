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
        /// Selects the first 100 instances.
        /// </summary>
        /// <param name="predicate">The LINQ expression.</param>
        /// <param name="orderBy">The order by clause. All order by's will be returned in ascending order.</param>
        /// <param name="skip">The number of records to skip. This helps with paging.</param>
        /// <param name="take">The number of records to take from the results. It cannot be 
        /// greater than 100.</param>
        /// <returns></returns>
        IList<T> SelectAll(Expression<Func<T, bool>> predicate,
            Expression<Func<T, object>> orderBy, int skip, int take);

        /// <summary>
        /// Returns the next available LB Number.
        /// This is a specialized method that should be in an 
        /// IComputerRespoitory interface that implements IRepository of type Computer.
        /// </summary>
        /// <returns></returns>
        string NextLbNumber();
    }
}