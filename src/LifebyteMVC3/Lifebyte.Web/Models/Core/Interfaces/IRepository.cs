namespace Lifebyte.Web.Models.Core.Interfaces
{
    public interface IRepository<T> where T : ICoreEntity
    {
        void Save(T entity);
    }
}
