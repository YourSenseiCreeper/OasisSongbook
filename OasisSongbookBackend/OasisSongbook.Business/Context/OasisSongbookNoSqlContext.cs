using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OasisSongbook.Business.Context.Collection.Base;
using OasisSongbook.Business.Model;
using OasisSongbook.Business.Model.Song;
using OasisSongbook.Business.Model.Songbook;

namespace OasisSongbook.Business.Context
{
    public class OasisSongbookNoSqlContext
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _db;
        private readonly INoSqlCollection<User> _users;
        private readonly INoSqlCollection<Song> _songs;
        private readonly INoSqlCollection<Songbook> _songbooks;

        public INoSqlCollection<User> Users { get { return _users; } }
        public INoSqlCollection<Song> Songs { get { return _songs; } }
        public INoSqlCollection<Songbook> Songbooks { get { return _songbooks; } }

        public OasisSongbookNoSqlContext(IOptions<OasisSongbookNoSqlOptions> options)
        {
            _client = new MongoClient(MongoClientSettings.FromConnectionString(options.Value.ConnectionString));
            _db = _client.GetDatabase(options.Value.DatabaseName);
            _users = new BaseNoSqlCollection<User>(_db, "Users");
            _songs = new BaseNoSqlCollection<Song>(_db, "Songs");
            _songbooks = new BaseNoSqlCollection<Songbook>(_db, "Songbooks");
        }
    }
}
