namespace Lifebyte.Web.Models.Core.Interfaces
{
    public interface IDataService<T> where T : ICoreEntity
    {
        void Save(T entity);
    }
}