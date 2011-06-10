using System;
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
        /// <remarks>http://www.4guysfromrolla.com/articles/112002-1.aspx</remarks>
        public string EncryptPassword(string password, Guid volunteerId)
        {
            byte[] saltedHash = new UTF8Encoding().GetBytes(Salt(volunteerId) + password);

            return Convert.ToBase64String(new SHA1CryptoServiceProvider().ComputeHash(saltedHash));
        }

        private string Salt(Guid volunteerId)
        {
            return string.Format("{0}{1}", Settings.Default.Salt, volunteerId);
        }
    }
}