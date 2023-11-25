using MongoDB.Driver;

namespace OasisSongbook.Business.Context.Collection.Base
{
    public interface INoSqlCollection<T> where T : class
    {
        Task Delete(FilterDefinition<T> filter);
        Task DeleteAll();
        Task<List<T>> GetAll();
        Task<T> Get(string id);
        Task Insert(params T[] entries);
        Task<List<T>> Query(FilterDefinition<T> filter);
        Task Replace(FilterDefinition<T> filter, T replacement);
        Task Update(FilterDefinition<T> filter, UpdateDefinition<T> update);
        Task Add(T item);
        Task AddRange(IEnumerable<T> items);
    }
}
