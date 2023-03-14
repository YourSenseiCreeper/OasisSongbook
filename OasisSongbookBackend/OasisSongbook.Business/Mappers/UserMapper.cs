using MongoDB.Bson;
using OasisSongbook.Business.Model;
using OasisSongbook.Business.Model.Dto;

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
                Songbooks = new List<Model.Songbook.Songbook>()
            };
        }
    }
}
