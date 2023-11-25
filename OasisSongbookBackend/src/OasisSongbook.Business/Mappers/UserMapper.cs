using MongoDB.Bson;
using OasisSongbook.Domain;
using OasisSongbook.Domain.Dto;
using OasisSongbook.Domain.Songbook;

namespace OasisSongbook.Business.Mappers
{
    public static class UserMapper
    {
        public static User ToUser(this CreateUserDto dto)
        {
            return new User
            {
                _id = ObjectId.GenerateNewId().ToString(),
                Email = dto.Email,
                Name = dto.Name,
                Role = dto.Role,
                IsActive = dto.IsActive,
                Songbooks = new List<Songbook>()
            };
        }
    }
}
