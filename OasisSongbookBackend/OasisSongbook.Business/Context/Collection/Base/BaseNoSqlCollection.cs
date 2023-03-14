using MongoDB.Bson;
using MongoDB.Driver;

namespace OasisSongbook.Business.Context.Collection.Base
{
    public class BaseNoSqlCollection<TEntity> : INoSqlCollection<TEntity> where TEntity : class
    {
        private readonly IMongoDatabase _db;
        private readonly string _collectionName;
        public BaseNoSqlCollection(IMongoDatabase database, string collectionName)
        {
            _db = database;
            _collectionName = collectionName;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _db.GetCollection<TEntity>(_collectionName).Find(Builders<TEntity>.Filter.Empty).ToListAsync();
        }

        public async Task<TEntity> Get(string id)
        {
            return await _db.GetCollection<TEntity>(_collectionName).Find(Builders<TEntity>.Filter.Eq("_id", new ObjectId(id))).FirstOrDefaultAsync();
        }

        public async Task<List<TEntity>> Query(FilterDefinition<TEntity> filter)
        {
            return await _db.GetCollection<TEntity>(_collectionName).Find(filter).ToListAsync();
        }

        public async Task Insert(params TEntity[] documents)
        {
            await _db.GetCollection<TEntity>(_collectionName).InsertManyAsync(documents);
        }

        public async Task Update(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update)
        {
            //var filter = Builders<TEntity>.Filter.Eq("name", "Wydział Nauk Ekonomicznych");
            //var update = Builders<TEntity>.Update.Set("name", "Wydział Gier i Zabaw"); //.Set("status", "P").CurrentDate("lastModified");
            await _db.GetCollection<TEntity>(_collectionName).UpdateOneAsync(filter, update);
        }

        public async Task Replace(FilterDefinition<TEntity> filter, TEntity replacement)
        {
            await _db.GetCollection<TEntity>(_collectionName).ReplaceOneAsync(filter, replacement);
        }

        public async Task Delete(FilterDefinition<TEntity> filter)
        {
            await _db.GetCollection<TEntity>(_collectionName).DeleteOneAsync(filter);
        }

        public async Task DeleteAll()
        {
            await _db.GetCollection<TEntity>(_collectionName).DeleteOneAsync(Builders<TEntity>.Filter.Empty);
        }

        public async Task Add(TEntity item)
        {
            await _db.GetCollection<TEntity>(_collectionName).InsertOneAsync(item);
        }

        public async Task AddRange(IEnumerable<TEntity> items)
        {
            await _db.GetCollection<TEntity>(_collectionName).InsertManyAsync(items);
        }
    }
}
