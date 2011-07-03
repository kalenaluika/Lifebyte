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
        /// We do not store plain text passwords in the database.
        /// This is the algorithm to encrypt the password. 
        /// In order to be more SOLID we should put this into a special
        /// IVolunteerDataService interface that implements IDataService of type Volunteer.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="volunteerId"></param>
        /// <returns></returns>
        string HashPassword(string password, Guid volunteerId);

        /// <summary>
        /// Returns the next available LB Number.
        /// This is a specialized method that should be in an 
        /// IComputerDataService interface that implements IDataService of type Computer.
        /// </summary>
        /// <returns></returns>
        string NextLbNumber();
    }
}