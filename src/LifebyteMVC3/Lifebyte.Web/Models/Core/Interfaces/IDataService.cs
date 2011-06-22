using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Lifebyte.Web.Models.Core.Interfaces
{
    public interface IDataService<T> where T : ICoreEntity
    {
        /// <summary>
        /// Inserts the entity to the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        void Insert(T entity, object id);

        /// <summary>
        /// Updates the entity to the database.
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Selects one instance of an entity.
        /// </summary>
        /// <param name="predicate">The query expression.</param>
        /// <returns></returns>
        T SelectOne(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Selects all of the instances.
        /// </summary>
        /// <param name="predicate">The query expression.</param>
        /// <returns></returns>
        IList<T> SelectAll(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// We do not store plain text passwords in the database.
        /// This is the algorithm to encrypt the password. 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="volunteerId"></param>
        /// <returns></returns>
        string HashPassword(string password, Guid volunteerId);
    }
}