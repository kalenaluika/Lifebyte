using Lifebyte.Web.Models.Core.Interfaces;

namespace Lifebyte.Web.Models.Services
{
    public class DataService<T> : IDataService<T> where T : ICoreEntity
    {
        private readonly IRepository<T> repository;

        public DataService(IRepository<T> repository)
        {
            this.repository = repository;
        }

        #region IDataService<T> Members

        public void Save(T entity)
        {             
            repository.Save(entity);
        }

        #endregion
    }
}