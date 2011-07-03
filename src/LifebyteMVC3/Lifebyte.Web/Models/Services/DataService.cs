using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using Lifebyte.Web.Models.Core.Interfaces;
using Lifebyte.Web.Properties;

namespace Lifebyte.Web.Models.Services
{
    public class DataService<T> : IDataService<T> where T : ICoreEntity
    {
        private readonly IRepository<T> repository;

        public DataService(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public void Insert(T entity, object id)
        {
            repository.Insert(entity, id);
        }

        public void Update(T entity)
        {
            repository.Update(entity);
        }

        /// <summary>
        /// Selects one instance of an entity.
        /// </summary>
        /// <param name="predicate">The LINQ expression.</param>
        /// <returns></returns>
        public T SelectOne(Expression<Func<T, bool>> predicate)
        {
            return repository.SelectOne(predicate);
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
            return repository.SelectAll(predicate, orderBy, skip, take);
        }

        /// <summary>
        /// We do not store plain text passwords in the database.
        /// This is the algorithm to encrypt the password. 
        /// In order to be more SOLID we should put this into a special
        /// IVolunteerDataService interface that implements IDataService of type Volunteer.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="volunteerId"></param>
        /// <returns></returns>
        /// <remarks>http://www.4guysfromrolla.com/articles/112002-1.aspx</remarks>
        public string HashPassword(string password, Guid volunteerId)
        {
            byte[] saltedHash = new UTF8Encoding().GetBytes(Salt(volunteerId) + password);

            return Convert.ToBase64String(new SHA1CryptoServiceProvider().ComputeHash(saltedHash));
        }

        private string Salt(Guid volunteerId)
        {
            return string.Format("{0}{1}", Settings.Default.Salt, volunteerId);
        }

        /// <summary>
        /// Returns the next available LB Number.
        /// This is a specialized method that should be in an 
        /// IComputerDataService interface that implements IDataService of type Computer.
        /// </summary>
        /// <returns></returns>
        public string NextLbNumber()
        {
            return repository.NextLbNumber();
        }
    }
}