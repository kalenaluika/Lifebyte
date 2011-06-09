using System.Security.Cryptography;
using System.Text;
using Lifebyte.Web.Models.Core.Interfaces;
using System;

namespace Lifebyte.Web.Models.Services
{
    public class DataService<T> : IDataService<T> where T : ICoreEntity
    {
        private readonly IRepository<T> repository;

        public DataService(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public void Save(T entity)
        {             
            repository.Save(entity);
        }

        /// <summary>
        /// We do not store plain text passwords in the database.
        /// This is the algorithm to encrypt the password. 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="volunteerId"></param>
        /// <returns></returns>
        public string EncryptPassword(string password, Guid volunteerId)
        {
            var salt = volunteerId.ToString();
            var saltedHash = new UTF8Encoding().GetBytes(salt + password);

            return Convert.ToBase64String(new SHA1CryptoServiceProvider().ComputeHash(saltedHash));
        }
    }
}