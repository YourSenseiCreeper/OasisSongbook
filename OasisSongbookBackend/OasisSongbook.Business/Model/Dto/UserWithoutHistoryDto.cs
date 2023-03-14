using MongoDB.Bson.Serialization.Attributes;
using OasisSongbook.Business.Model.Enum;

namespace OasisSongbook.Business.Model.Dto
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
