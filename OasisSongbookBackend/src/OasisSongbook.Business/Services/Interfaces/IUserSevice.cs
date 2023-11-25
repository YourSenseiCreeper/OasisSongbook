using OasisSongbook.Domain.Dto;

namespace OasisSongbook.Business.Services.Interfaces
{
    public interface IUserSevice
    {
        Task CreateUser(CreateUserDto userDto);
    }
}
