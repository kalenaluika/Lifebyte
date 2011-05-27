using Lifebyte.Web.Models.Core.Interfaces;

namespace Lifebyte.Web.Models.Data
{
    public class Repository<T> : IRepository<T> where T : ICoreEntity
    {
        public void Save(T entity)
        {
            // http://jameskovacs.com/2011/01/21/loquacious-configuration-in-nhibernate-3/
            // TODO Work on saving to the database.
            throw new System.NotImplementedException();
        }
    }
}