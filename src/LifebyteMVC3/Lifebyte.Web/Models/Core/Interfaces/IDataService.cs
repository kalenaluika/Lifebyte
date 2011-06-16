using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Lifebyte.Web.Models.Core.Interfaces
{
    public interface IDataService<T> where T : ICoreEntity
    {
        /// <summary>
        /// Saves the entity to the database.
        /// </summary>
        /// <param name="entity"></param>
        void Save(T entity);

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

        /// <summary>
        /// We do not store plain text passwords in the database.
        /// This is the algorithm to encrypt the password. 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="volunteerId"></param>
        /// <returns></returns>
        string EncryptPassword(string password, Guid volunteerId);
    }
}