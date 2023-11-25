using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OasisSongbook.Domain.Enum;

namespace OasisSongbook.Domain
{
    public class User
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public UserRole Role { get; set; }
        public List<Songbook.Songbook> Songbooks { get; set; }
    }
}
