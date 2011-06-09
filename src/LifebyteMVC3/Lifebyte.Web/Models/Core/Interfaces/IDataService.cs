using System;

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
        /// We do not store plain text passwords in the database.
        /// This is the algorithm to encrypt the password. 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="volunteerId"></param>
        /// <returns></returns>
        string EncryptPassword(string password, Guid volunteerId);
    }
}