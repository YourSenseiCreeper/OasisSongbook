using MongoDB.Bson.Serialization.Attributes;
using OasisSongbook.Domain.Enum;

namespace OasisSongbook.Domain.Dto
{
    [BsonIgnoreExtraElements]
    public class UserWithoutHistoryDto
    {
        public string _id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public UserRole Role { get; set; }
    }
}
